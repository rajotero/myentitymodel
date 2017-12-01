using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using MyEntityModel;
using System.IO;
using System.Net;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using System.Threading;
using DevExpress.XtraEditors;

namespace Gestion_WF.Ebay
{
    public partial class EbayUserControl : UserControl
    {
        bool LayoutControlEbaycompetenciaCargada = false;
        string codigoActual;
        public EbayUserControl()
        {
            InitializeComponent();
            this.HandleDestroyed += handleDestroyed;
            if (File.Exists("Layouts\\EbayUserControl\\layout.xml"))
            {
                layoutControl1.RestoreLayoutFromXml("Layouts\\EbayUserControl\\layout.xml");
            }
            if (File.Exists("Layouts\\EbayUserControl\\gridViewEbay.xml"))
            {
                gridViewEbay.RestoreLayoutFromXml("Layouts\\EbayUserControl\\gridViewEbay.xml");
            }
        }

        private void handleDestroyed(object sender, EventArgs e)
        {
           if (LayoutControlEbaycompetenciaCargada)
            {
                gridViewEbaycompetencia.SaveLayoutToXml("Layouts\\EbayUserControl\\gridViewEbaycompetencia.xml");
            }
            gridViewEbay.SaveLayoutToXml("Layouts\\EbayUserControl\\gridViewEbay.xml");
            layoutControl1.SaveLayoutToXml("Layouts\\EbayUserControl\\layout.xml");
        }
 
        public void Cargar(string codigo)
        {
           
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            List<string> ListaCodigos = FuncionesEbay.fnListaCodigos(codigo);
            string CadenaIn = "";
            foreach (var c in ListaCodigos)
            {
                CadenaIn += "'" + c + "'";
            }
            CadenaIn = CadenaIn.Replace("''", "','");

            string sql = string.Format("Select * from EBAY_SEGUIMIENTO where (articulo_mio in ({0}) or codigo in ({0})) and vendedor in ({1})", CadenaIn, Global.CuentasEbaySQL);
            var a = dbContext.Database.SqlQuery<MyEntityModel.EBAY_SEGUIMIENTO>(sql).ToList();
            gridControlEbay.Invoke((MethodInvoker)(() => gridControlEbay.DataSource = a));
            costosEbayUserControl1.articuloEbayID = "";
        }
        private void gridViewEbay_Click(object sender, EventArgs e)
        {
            GridView view = gridViewEbay;
            int currentRowHandle = view.FocusedRowHandle;
            MyEntityModel.EBAY_SEGUIMIENTO row = (MyEntityModel.EBAY_SEGUIMIENTO)view.GetRow(currentRowHandle);
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            List<EBAY_SEGUIMIENTO> articulos = dbContext.EBAY_SEGUIMIENTO.Where(w => w.CODIGO.Trim() == row.ARTICULO_MIO).ToList();
            codigoActual = row.ARTICULO_MIO.Trim();
            gridControlEbaycompetencia.DataSource = articulos;
            if (!LayoutControlEbaycompetenciaCargada)
            {
                if (File.Exists("Layouts\\EbayUserControl\\gridViewEbaycompetencia.xml"))
                {
                    gridViewEbaycompetencia.RestoreLayoutFromXml("Layouts\\EbayUserControl\\gridViewEbaycompetencia.xml");
                }
                LayoutControlEbaycompetenciaCargada = true;
            }

            if (layoutControlGroupImagenes.Visible)
            {
  //              PintarImagenesEbay(row);
  //              new Thread(new ThreadStart(PintarImagenesEbay(row))).Start();
                Thread thread = new Thread(() => PintarImagenesEbay(row));
                thread.Start();
            }
            costosEbayUserControl1.articuloEbayID =   row.ARTICULO;
        }

        private void PintarImagenesEbay(MyEntityModel.EBAY_SEGUIMIENTO row)
        {
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            dbContext.LeerArticuloEbay(row.ARTICULO, row.VENDEDOR, row.ARTICULO_MIO, row.CODIGO);
            EBAY_SEGUIMIENTO ebay = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == row.ARTICULO).FirstOrDefault();
            List<string> ListaImagenes = new List<string>();
            imageSliderEbay.Images.Clear();
            ListaImagenes.Clear();

            if (ebay.PictureURL != null)
            {

                string[] URLs = ebay.PictureURL.Split('\t');

                foreach (string url in URLs)
                {
                    Uri uri = new Uri(url);
                    string fil = uri.Segments[5];
                    fil = fil.Remove(fil.Length - 1);
                    fil = fil + ".jpg";
                    var directorio = string.Format(".\\{0}\\{1}\\{2}\\{3}", fil[0], fil[1], fil[2], fil[3]);
                    Directory.CreateDirectory(directorio);
                    fil = directorio + "\\" + fil;
                    if (!System.IO.File.Exists(fil))
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(url, fil);
                    }
                    imageSliderEbay.Images.Add(Image.FromFile(fil));
                }
            }
        }

        private class ArticulosLeerEbay
        {
            public string Vendedor { get; set; }
            public string Articulo { get; set; }
        }
        private void simpleButtonReleerLosMios_Click(object sender, EventArgs e)
        {
            simpleButtonReleerLosMios.Enabled = false;
            string caption = simpleButtonReleerLosMios.Text;
            simpleButtonReleerLosMios.Text="Leyendo";
            List<ArticulosLeerEbay> articulosLeerEbay = new List<ArticulosLeerEbay>();
            int i;
            for (i = 0; i < gridViewEbay.DataRowCount; i++)
            {
                string vendedor = (string)gridViewEbay.GetRowCellValue(i, "VENDEDOR");
                string articulo = (string)gridViewEbay.GetRowCellValue(i, "ARTICULO");
                articulosLeerEbay.Add(new ArticulosLeerEbay { Vendedor = vendedor, Articulo = articulo });
//                MyEntityModel.FuncionesEbay.LeerArticuloEbay(articulo, vendedor);
            }
            Parallel.ForEach(articulosLeerEbay, f => MyEntityModel.FuncionesEbay.LeerArticuloEbay(f.Articulo, f.Vendedor));
            simpleButtonReleerLosMios.Enabled = true;
            simpleButtonReleerLosMios.Text=caption;
        }

        private void gridViewEbay_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                e.Menu.Items.Clear();

                int colId = e.HitInfo.Column.ColumnHandle;
                int rowId = e.HitInfo.RowHandle;
                DevExpress.Utils.Menu.DXMenuItem dxMenuItem;
                dxMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Abrir Articulo", AbrirArticulo_click);
                e.Menu.Items.Add(dxMenuItem);
                dxMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Poner Disponible", PonerDisponibleArticulo_click);
                e.Menu.Items.Add(dxMenuItem);
            }
        }

        void PonerDisponibleArticulo_click(object sender, EventArgs e)
        {
            GridView view = gridViewEbay;
            int currentRowHandle = view.FocusedRowHandle;
            MyEntityModel.EBAY_SEGUIMIENTO row = (MyEntityModel.EBAY_SEGUIMIENTO)view.GetRow(currentRowHandle);
            CredencialesEbay credencialeebay = new CredencialesEbay();
            credencialeebay.cuenta = row.VENDEDOR;
            ItemType item = new ItemType();
            ReviseFixedPriceItemCall reviseFP = new ReviseFixedPriceItemCall(credencialeebay.context);
            item.Quantity = 20;
            item.ItemID = row.ARTICULO;
            reviseFP.Item = item;
            try
            {
                reviseFP.Execute();
                FuncionesEbay.fnGrabarErrorEbayArticulo(row.ARTICULO,"");
            }
            catch (Exception ex)
            {
                FuncionesEbay.fnGrabarErrorEbayArticulo(row.ARTICULO, ex.Message);
            }
            Console.WriteLine(reviseFP.ApiResponse.Ack + " Revised SKU " + reviseFP.ItemID);
        }
        void AbrirArticulo_click(object sender, EventArgs e)
        {
            GridView view = gridViewEbay;
            int currentRowHandle = view.FocusedRowHandle;
            MyEntityModel.EBAY_SEGUIMIENTO row = (MyEntityModel.EBAY_SEGUIMIENTO)view.GetRow(currentRowHandle);
            System.Diagnostics.Process.Start("http://www.ebay.es/itm/"+row.ARTICULO);
        }

        private void PintarImagenesEbayCompetencia(MyEntityModel.EBAY_SEGUIMIENTO row)
        {
            if (row == null)
                return;
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            dbContext.LeerArticuloEbay(row.ARTICULO, row.VENDEDOR, row.ARTICULO_MIO, row.CODIGO);
            EBAY_SEGUIMIENTO ebay = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == row.ARTICULO).FirstOrDefault();
            List<string> ListaImagenes = new List<string>();
            imageSliderCompetencia.Images.Clear();
            ListaImagenes.Clear();

            if (ebay.PictureURL != null)
            {

                string[] URLs = ebay.PictureURL.Split('\t');

                foreach (string url in URLs)
                {
                    Uri uri = new Uri(url);
                    string fil = uri.Segments[5];
                    fil = fil.Remove(fil.Length - 1);
                    fil = fil + ".jpg";
                    var directorio = string.Format(".\\{0}\\{1}\\{2}\\{3}", fil[0], fil[1], fil[2], fil[3]);
                    Directory.CreateDirectory(directorio);
                    fil = directorio + "\\" + fil;
                    if (!System.IO.File.Exists(fil))
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(url, fil);
                    }
                    imageSliderCompetencia.Images.Add(Image.FromFile(fil));
                }
            }
            if (imageSliderCompetencia.Images.Count == 0)
            {
                Uri uri = new Uri(ebay.IMAGEN_EBAY);
                string fil = uri.Segments[5];
                fil = fil.Remove(fil.Length - 1);
                fil = fil + ".jpg";
                var directorio = string.Format(".\\{0}\\{1}\\{2}\\{3}", fil[0], fil[1], fil[2], fil[3]);
                Directory.CreateDirectory(directorio);
                fil = directorio + "\\" + fil;
                if (!System.IO.File.Exists(fil))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(ebay.IMAGEN_EBAY, fil);
                }
                imageSliderCompetencia.Images.Add(Image.FromFile(fil));
            }
        }

        private void gridViewEbaycompetencia_Click(object sender, EventArgs e)
        {
            GridView view = gridViewEbaycompetencia;
            int currentRowHandle = view.FocusedRowHandle;
            MyEntityModel.EBAY_SEGUIMIENTO row = (MyEntityModel.EBAY_SEGUIMIENTO)view.GetRow(currentRowHandle);
            new Thread(() => PintarImagenesEbayCompetencia(row)).Start();
        }

        private void buttonEditAnadirCompetencia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ItemType item = MyEntityModel.FuncionesEbay.LeerArticuloEbay(buttonEditAnadirCompetencia.Text, "");
            if (item == null)
            {
                XtraMessageBox.Show("Número de artículo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RepuestosDeMovilesDbContext dbContext = new RepuestosDeMovilesDbContext();
            int cuantos = dbContext.EBAY_SEGUIMIENTO.Where(w => w.ARTICULO == buttonEditAnadirCompetencia.Text.Trim() && w.CODIGO == codigoActual).Count();
            if (cuantos > 0 )
            {
                XtraMessageBox.Show("Este artículo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MyEntityModel.FuncionesEbay.fnAnadirCompetenciaSeguimiento(item, codigoActual);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
