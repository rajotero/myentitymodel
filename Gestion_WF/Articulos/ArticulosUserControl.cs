using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using DevExpress.XtraGrid.Columns;
using System.IO;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using MyEntityModel;
using eBay.Service.Core.Soap;
using System.Collections;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;

namespace Gestion_WF.Articulos
{
    public partial class ArticulosUserControl : UserControl
    {


        MyEntityModel.ApplicationDbContextSql dataContextArticulos = new MyEntityModel.ApplicationDbContextSql();
        MyEntityModel.RajoteroDbContext dataContextRajotero = new MyEntityModel.RajoteroDbContext();
        GridColumn colUnidadesRecibidas= new GridColumn();
        List<int> rowNoDisponibles = new List<int>();

        List<string> ListaImagenes = new List<string>();

        private int fFocusedRowHandle;
        private int fTopRowIndex;
        //private bool fLoading;
        //private bool PrimeraVezFocusedRow = true;

        bool LayoutControlVentasCargada = false;
        public ArticulosUserControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.HandleDestroyed += handleDestroyed;
            if (File.Exists("Layouts\\Articulos\\gridViewArticulos.xml"))
            {
                gridViewArticulos.RestoreLayoutFromXml("Layouts\\Articulos\\gridViewArticulos.xml");
            }
            if (File.Exists("Layouts\\Articulos\\layout.xml"))
            {
                layoutControl1.RestoreLayoutFromXml("Layouts\\Articulos\\layout.xml");
            }
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\Rajotero\\Articulos", true);
            if (reg == null)
            {
                reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rajotero\\Articulos");
            }
            if (reg != null)
            {
                radioGroupRajotero.SelectedIndex = (int)reg.GetValue("Rajotero", 0);
                radioGroupEscandallo.SelectedIndex = (int)reg.GetValue("Escandallo", 0);
                radioGroupActivos.SelectedIndex = (int)reg.GetValue("Activo", 0);
                textEditPalabras.Text = (string)reg.GetValue("Palabras", "");
                textEditDelEnvio.Text = (string)reg.GetValue("Envio", "");
            }
            if (File.Exists("Layouts\\Articulos\\gridViewCompras.xml"))
            {
                gridViewCompras.RestoreLayoutFromXml("Layouts\\Articulos\\gridViewCompras.xml");
            }



            MyEntityModel.ApplicationDbContextSql dbContext = new MyEntityModel.ApplicationDbContextSql();
            dbContext.TipoArticulos.Load();
            repositoryItemLookUpEditTipoArticulo1.DataSource = dbContext.TipoArticulos.Local.ToBindingList();
            repositoryItemLookUpEditTipoArticulo1.DisplayMember = "Nombre";
            repositoryItemLookUpEditTipoArticulo1.ValueMember = "TipoArticuloID";

            FechaActualizacionTotalesArticulo();

            
            GridColumn colStock = new GridColumn();
            colStock.FieldName = "Stock";
            colStock.Caption = "Stock";
            colStock.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridViewArticulos.Columns.Add(colStock);
            colStock.VisibleIndex = 0;

            colUnidadesRecibidas.FieldName = "UnidadesRecibidas";
            colUnidadesRecibidas.Caption = "UnidadesRecibidas";
            colUnidadesRecibidas.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridViewArticulos.Columns.Add(colUnidadesRecibidas);
            colUnidadesRecibidas.VisibleIndex = 0;
            LoadSource();
            // Prevent the focused cell from being highlighted.
            gridViewArticulos.OptionsSelection.EnableAppearanceFocusedCell = false;
            // Draw a dotted focus rectangle around the entire row.
            gridViewArticulos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            CredencialesEbay credenciales = new CredencialesEbay();

            foreach (string cuenta in credenciales.Cuentas)
            {
                LayoutControlItem item1 = layoutControlCuentas.Root.AddItem();
                item1.Name = "Ebay " + cuenta;
                item1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
                item1.MaxSize = new Size(205,30);
                ComboBoxEdit comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                comboBoxEdit1.Name = "Ebay " + cuenta;
                comboBoxEdit1.Properties.Items.AddRange(new object[] {
                    "Todos",
                    "Publicados",
                    "Sin publicar"});
                comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                comboBoxEdit1.Properties.PopupFormSize = new Size(50, comboBoxEdit1.Properties.PopupFormSize.Height);
                comboBoxEdit1.Size = new Size(50, comboBoxEdit1.Properties.PopupFormSize.Height);
                comboBoxEdit1.SelectedIndex = (int)reg.GetValue(comboBoxEdit1.Name, 0);
                item1.Control = comboBoxEdit1;
            }
            foreach (string cuenta in Global.CuentasAmazon)
            {
                LayoutControlItem item1 = layoutControlCuentas.Root.AddItem();
                item1.Name = "Amazon " + cuenta;
                item1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
                item1.MaxSize = new Size(205, 30);
                ComboBoxEdit comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
                comboBoxEdit1.Name = "Amazon " + cuenta;
                comboBoxEdit1.Properties.Items.AddRange(new object[] {
                    "Todos",
                    "Publicados",
                    "Sin publicar"});
                comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                comboBoxEdit1.Properties.PopupFormSize = new Size(50, comboBoxEdit1.Properties.PopupFormSize.Height);
                comboBoxEdit1.Size = new Size(50, comboBoxEdit1.Properties.PopupFormSize.Height);
                comboBoxEdit1.SelectedIndex = (int)reg.GetValue(comboBoxEdit1.Name, 0);
                item1.Control = comboBoxEdit1;
            }
        }


        private void LoadSource()
        {
            var dataContextArticulos = new MyEntityModel.ApplicationDbContextSql();
            string were = " Select * from Articulos where ArticuloID > 0 ";
            string lista = "";
            var dataContextRajotero = new MyEntityModel.RajoteroDbContext();
            var dataContextRepuestos = new MyEntityModel.RepuestosDeMovilesDbContext();
            if (radioGroupRajotero.SelectedIndex != 0)
            {
                var a = dataContextRajotero.ps_product.Where(w => w.reference.Trim() != "").Select(s => s.reference.Trim()).ToList();
                lista = "'" + String.Join("','", a) + "'";
            }
            if (radioGroupRajotero.SelectedIndex == 1)  // Publicados en rajotero
            {
                    were += " and Codigo in  (" + lista + ") ";
            }
            if (radioGroupRajotero.SelectedIndex == 2)  // Sin Publicar en rajotero
                {
                    were += " and Codigo not in  (" + lista + ") ";
                }
            if (radioGroupEscandallo.SelectedIndex == 1)  // Con Escandallo
                {
                    were += " and ArticuloID in (Select ArticuloID from Escandallo) ";
                }
            if (radioGroupEscandallo.SelectedIndex == 2) // Sin Escandallo
                {
                    were += " and ArticuloID not in (Select ArticuloID from Escandallo) ";
                }
            if (radioGroupActivos.SelectedIndex == 1)
                {
                    were += " and Activo = 1 ";
                }
            if (radioGroupActivos.SelectedIndex == 2)
                {
                    were += " and Activo = 0 ";
                }

            foreach (DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit in layoutControlCuentas.Controls.OfType<DevExpress.XtraEditors.ComboBoxEdit>())
            {
                if (comboBoxEdit.Name.Contains("Ebay"))
                {
                    string cuenta = comboBoxEdit.Name.Split(' ')[1];
                    if (comboBoxEdit.Text != "Todos")
                    {
                        List<string> codigos = dataContextRepuestos.EBAY_SEGUIMIENTO.Where(w => w.VENDEDOR == cuenta).Select(s => s.ARTICULO_MIO.Trim()).ToList();
                        lista = "'" + String.Join("','", codigos) + "'";
                        if (comboBoxEdit.Text == "Publicados")
                        {
                            were += " and Codigo in (" + lista + ") ";
                        }

                        if (comboBoxEdit.Text == "Sin publicar")
                        {
                            were += " and Codigo not in (" + lista + ") ";
                        }

                    }
                }
            }


            if (textEditDelEnvio.Text.Trim() != "")
            {
                int NumeroEnvio = 0;
                try
                {
                    NumeroEnvio = Convert.ToInt16(textEditDelEnvio.Text);
                }
                catch
                { }
                if (NumeroEnvio != 0)
                {
                    MyEntityModel.RepuestosDeMovilesDbContext dbContextRepuestos = new MyEntityModel.RepuestosDeMovilesDbContext();
                    var a = dbContextRepuestos.L_ENVIOS.Where(w => w.CABECERA == NumeroEnvio).Select(s => s.ARTICULO).ToList();
                    string listaEnvio = "'" + String.Join("','", a) + "'";
                    if (listaEnvio.Trim() != "")
                    {
                        were += " and Codigo in  (" + listaEnvio + ") ";
                    }
                    colUnidadesRecibidas.Visible = true;
                }
                else
                {
                       colUnidadesRecibidas.Visible = false;
                }
            }
            var palabras = textEditPalabras.Text.Split(' ');
            foreach (string palabra in palabras)
                {
                    if (palabra.FirstOrDefault() == '-')
                    {
                        var p = palabra.Remove(0, 1);
                        were += " AND nombre not like '%" + p + "%' ";
                    }
                    else
                    {
                        were += " AND nombre like '%" + palabra + "%' ";
                    }
                }
            IList<MyEntityModel.Articulo> articulos = dataContextArticulos.Database.SqlQuery<MyEntityModel.Articulo>(were).ToList();
            gridControlArticulos.DataSource = articulos;
            layoutControlGroupFiltros.Text = "Articulos Encontrados " + articulos.Count.ToString();
        }

        private void handleDestroyed(object sender, EventArgs e)
        {
            gridViewArticulos.SaveLayoutToXml("Layouts\\Articulos\\gridViewArticulos.xml");
            if (LayoutControlVentasCargada)
            {
                gridViewVentas.SaveLayoutToXml("Layouts\\Articulos\\gridViewVentas.xml");
            }
            gridViewCompras.SaveLayoutToXml("Layouts\\Articulos\\gridViewCompras.xml");
             RegistryKey reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\Rajotero\\Articulos", true);
            if (reg == null)
            {
                reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rajotero\\Articulos");
            }
            if (reg != null)
            {
                reg.SetValue("Rajotero", radioGroupRajotero.SelectedIndex);
                reg.SetValue("Escandallo", radioGroupEscandallo.SelectedIndex);
                reg.SetValue("Activo", radioGroupActivos.SelectedIndex);
                reg.SetValue("Palabras", textEditPalabras.Text);
                reg.SetValue("Envio", textEditDelEnvio.Text);
//                reg.SetValue("splitterItem1", splitterItem1.Location.X);
            }
            foreach (DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit in layoutControlCuentas.Controls.OfType<DevExpress.XtraEditors.ComboBoxEdit>())
            {
//                ComboBoxEdit comboBoxEdit = (ComboBoxEdit)layoutControlItem.Control;
                reg.SetValue(comboBoxEdit.Name, comboBoxEdit.SelectedIndex);
            }
            layoutControl1.SaveLayoutToXml("Layouts\\Articulos\\layout.xml");
        }

        private void ButtonFechaActualizacionTotalesArticulo_Click(object sender, EventArgs e)
        {
            var dataContext = new MyEntityModel.ApplicationDbContextSql();
            string sql;

            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando ArticuloComprado"; Application.DoEvents();
            sql = "UPDATE lineas SET ArticuloCompradoID = (SELECT ArticuloId FROM Articulos a WHERE a.Codigo = ArticuloComprado)";
            dataContext.Database.ExecuteSqlCommand(sql);

            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos - 1"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidos = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) " +
                 ")", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql);

            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Comprados - 1"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET comprados = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ('B')" +
                ")");
            dataContext.Database.ExecuteSqlCommand(sql);

            DateTime Siete = DateTime.Now.AddDays(-7);
            var parameters = new List<SqlParameter> {
                            new SqlParameter { ParameterName = "@Fecha", SqlDbType = SqlDbType.DateTime, Value = Siete }
                        };
            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos Semana - 1"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidossiete = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) and l.fecha >= @Fecha" +
                ")", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql, new SqlParameter { ParameterName = "@Fecha", SqlDbType = SqlDbType.DateTime, Value = Siete });

            DateTime Treinta = DateTime.Now.AddDays(-30);
            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos Mes - 1"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidostreinta = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) and l.fecha >= @Fecha" +
                 " AND ((SELECT COUNT(*) FROM Escandallo e WHERE e.ArticuloID = Articulos.ArticuloID) = 0)" +
                ")", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql, new SqlParameter { ParameterName = "@Fecha", SqlDbType = SqlDbType.DateTime, Value = Treinta });


            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos - 2"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidos = (" +
                "SELECT SUM(UnidadesArticuloComprado) from lineas l WHERE l.ArticuloCompradoID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) " +
                 " )" +
                 " WHERE ((SELECT COUNT(*) FROM Escandallo e WHERE e.ArticuloID = Articulos.ArticuloID) > 0)", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql);

            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos Semana - 2"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidossiete = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloCompradoID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) and l.fecha >= @Fecha" +
                 " )" +
                " WHERE ((SELECT COUNT(*) FROM Escandallo e WHERE e.ArticuloID = Articulos.ArticuloID) > 0)", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql, new SqlParameter { ParameterName = "Fecha", SqlDbType = SqlDbType.DateTime, Value = Siete });

            ButtonFechaActualizacionTotalesArticulo.Text = "Actualizando Vendidos Mes - 2"; Application.DoEvents();
            sql = string.Format("UPDATE articulos  SET vendidostreinta = (" +
                "SELECT SUM(unidades) from lineas l WHERE l.ArticuloCompradoID = articulos.ArticuloID AND  SUBSTRING(l.Tipo, 3, 1) IN ({0}) and l.fecha >= @Fecha" +
                 " )" +
                " WHERE ((SELECT COUNT(*) FROM Escandallo e WHERE e.ArticuloID = Articulos.ArticuloID) > 0)", Global.TiposVentasSQL);
            dataContext.Database.ExecuteSqlCommand(sql, new SqlParameter { ParameterName = "Fecha", SqlDbType = SqlDbType.DateTime, Value = Treinta });


            MyEntityModel.Datos datos = dataContext.datos.FirstOrDefault();
            if (datos == null)
            {
                datos = new MyEntityModel.Datos();
                datos.FechaActualizacionTotalesArticulo = DateTime.Now;
                dataContext.datos.Add(datos);
            }
            else
            {
                datos.FechaActualizacionTotalesArticulo = DateTime.Now;

            }
            dataContext.SaveChanges();
            FechaActualizacionTotalesArticulo();
        }

        private void FechaActualizacionTotalesArticulo()
        {
            MyEntityModel.Datos datos = dataContextArticulos.datos.FirstOrDefault();
            if (datos != null)
            {
                DateTime fecha = (DateTime)datos.FechaActualizacionTotalesArticulo;
                ButtonFechaActualizacionTotalesArticulo.Text = datos.FechaActualizacionTotalesArticulo == null ? "Actualizar Totales" : "Act.Totales " + fecha.ToString("dd/MM HH:mm");
            }
        }


        #region Funciones Imagenes

        private void SubirImagen(string file, string codigo)
        {
            Chilkat.Ftp2 ftp = new Chilkat.Ftp2();
            bool success;
            ftp.Hostname = "www.repuestosdemoviles.es";
            ftp.Username = "repuestosdemovil";
            ftp.Password = "952501712";
            success = ftp.Connect();
            if (success != true)
            {
                Console.WriteLine(ftp.LastErrorText);
                return;
            }

            string cwd = "httpdocs/ebay/imagenes/" + codigo.Trim();
            string BaseUrl = "http://www.repuestosdemoviles.es/ebay/imagenes/" + codigo.Trim();
            success = ftp.ChangeRemoteDir(cwd);
            success = ftp.PutFile(file, Path.GetFileName(file));
            if (success != true)
            {
                Console.WriteLine(ftp.LastErrorText);
                return;
            }
            ftp.Disconnect();
        }
        private void CargarImagenes(string codigo)
        {
            imageSlider1.Images.Clear();
            ListaImagenes.Clear();
            Chilkat.Ftp2 ftp = new Chilkat.Ftp2();
            bool success;
            //success= ftp.UnlockComponent("CRNsu3.CB10699_Zu6BhW7yjEkG");
            //if (success != true)
            //{
            //    Console.WriteLine(ftp.LastErrorText);
            //    return;
            //}

            ftp.Hostname = "www.repuestosdemoviles.es";
            ftp.Username = "repuestosdemovil";
            ftp.Password = "952501712";
            success = ftp.Connect();
            if (success != true)
            {
                Console.WriteLine(ftp.LastErrorText);
                return;
            }

            string cwd = "httpdocs/ebay/imagenes/" + codigo.Trim();
            string BaseUrl = "http://www.repuestosdemoviles.es/ebay/imagenes/" + codigo.Trim();
            success = ftp.ChangeRemoteDir(cwd);
            int i;
            int n;
            int NumeroFotos = 0;
            n = ftp.GetDirCount();
            if (n > 0)
            {
                for (i = 0; i <= n - 1; i++)
                {
                    if (ftp.GetIsDirectory(i) == false)
                    {
                        WebClient wc = new WebClient();
                        string filename = BaseUrl + "/" + ftp.GetFilename(i);
                        byte[] bytes = wc.DownloadData(filename);
                        MemoryStream ms = new MemoryStream(bytes);
                        imageSlider1.Images.Add(Image.FromStream(ms));
                        ListaImagenes.Add(ftp.GetFilename(i));
                        NumeroFotos++;
                    }
                }
            }
            success = ftp.Disconnect();
            textEditNumeroImagenes.Text = NumeroFotos.ToString();
        }

        private void ButtonSubirImagen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Imágenes (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog.Title = "Selecciona las imágenes a subir";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string codigo = (string)gridViewArticulos.GetRowCellValue(gridViewArticulos.FocusedRowHandle, colCodigo);
                foreach (String file in openFileDialog.FileNames)
                {
                    SubirImagen(file, codigo);
                }
                CargarImagenes(codigo);
            }
        }

        private void ButtonBorrarImagen_Click(object sender, EventArgs e)
        {
            Chilkat.Ftp2 ftp = new Chilkat.Ftp2();
            bool success;
            ftp.Hostname = "www.repuestosdemoviles.es";
            ftp.Username = "repuestosdemovil";
            ftp.Password = "952501712";
            success = ftp.Connect();
            if (success != true)
            {
                Console.WriteLine(ftp.LastErrorText);
                return;
            }
            string codigo = (string)gridViewArticulos.GetRowCellValue(gridViewArticulos.FocusedRowHandle, colCodigo);
            string cwd = "httpdocs/ebay/imagenes/" + codigo.Trim();
            string BaseUrl = "http://www.repuestosdemoviles.es/ebay/imagenes/" + codigo.Trim();
            success = ftp.ChangeRemoteDir(cwd);
            var i = imageSlider1.CurrentImageIndex;
            string filename = ListaImagenes[i];
            ftp.DeleteRemoteFile(filename);
            ftp.Disconnect();
            CargarImagenes(codigo);
        }

        #endregion



       

        private void gridViewArticulos_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "Stock" && e.IsGetData)
            {
                int comprados = (int)Convert.ToInt64(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "comprados"));
                int vendidos = (int)Convert.ToInt64(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Vendidos"));
                if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Codigo").ToString().Trim() == "3161")
                {
                    e.Value = "A";
                }
                e.Value = comprados - vendidos;
            }
            if (e.Column.FieldName == "UnidadesRecibidas" && e.IsGetData)
            {
                int NumeroEnvio = 0;
                try
                {
                    NumeroEnvio = Convert.ToInt16(textEditDelEnvio.Text);
                }
                catch
                { }
                if (NumeroEnvio == 0)
                    return;
                MyEntityModel.RepuestosDeMovilesDbContext dbContextRepuestos = new MyEntityModel.RepuestosDeMovilesDbContext();
                string codigo = (string)view.GetListSourceRowCellValue(e.ListSourceRowIndex, "Codigo");
               
                try
                {
                    var a = dbContextRepuestos.L_ENVIOS.Where(w => w.ARTICULO == codigo && w.CABECERA == NumeroEnvio).Select(s => s.UNIDADES).FirstOrDefault().Value;
                    e.Value = Convert.ToInt16(a);
                }
                catch
                {

                }

            }
        }

        private void ventas7(int ArticuloID)
        {
            DateTime today = DateTime.Now;
            DateTime semana = today.AddDays(-7);
            if (dataContextArticulos.Lineas != null)
            {
                int a = dataContextArticulos.Lineas.Where(w => w.ArticuloID == ArticuloID && w.Fecha >= semana).Sum(s => (int?)s.Unidades) ?? 0;
                if (a == 0)
                {
                    a = dataContextArticulos.Lineas.Where(w => w.ArticuloCompradoID == ArticuloID && w.Fecha >= semana).Sum(s => (int?)s.UnidadesArticuloComprado) ?? 0;
                }
                textEdit7.Text = a.ToString();
            }
            else
            {
                textEdit7.Text = "0";
            }
        }
        private void ventas30(int ArticuloID)
        {
            DateTime today = DateTime.Now;
            DateTime semana = today.AddDays(-30);
            if (dataContextArticulos.Lineas != null)
            {
                int a = dataContextArticulos.Lineas.Where(w => w.ArticuloID == ArticuloID && w.Fecha >= semana).Sum(s => (int?)s.Unidades) ?? 0;
                if (a == 0)
                {
                    a = dataContextArticulos.Lineas.Where(w => w.ArticuloCompradoID == ArticuloID && w.Fecha >= semana).Sum(s => (int?)s.UnidadesArticuloComprado) ?? 0;
                }
                textEdit30.Text = a.ToString();
            }
            else
            {
                textEdit30.Text = "0";
            }
        }
        private void ventas(int ArticuloID)
        {
            if (dataContextArticulos.Lineas != null)
            {
                int a = dataContextArticulos.Lineas.Where(w => w.ArticuloID == ArticuloID).Sum(s => (int?)s.Unidades) ?? 0;
                if (a == 0)
                {
                    a = dataContextArticulos.Lineas.Where(w => w.ArticuloCompradoID == ArticuloID).Sum(s => (int?)s.UnidadesArticuloComprado) ?? 0;
                }
                textEditTotales.Text = a.ToString();
            }
            else
            {
                textEditTotales.Text = "0";
            }

        }

        private void gridViewArticulos_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void gridViewVentas_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            int currentRowHandle = view.FocusedRowHandle;
            MyEntityModel.Linea row = (MyEntityModel.Linea)view.GetRow(currentRowHandle);
            if (row != null)
            {
                textEditFacturaCliente.Text = row.Cabecera.cliente.Nombre;
                gridControlFacuraLineas.DataSource = row.Cabecera.Lineas;
            }
            else
            {
                gridControlFacuraLineas.DataSource = null;
            }
        }

        private void simpleButtonFiltrar_Click(object sender, EventArgs e)
        {
            LoadSource();
        }


        private void pintarPedidos()
        {
            ApplicationDbContextSql dbcontext = new ApplicationDbContextSql();
            RepuestosDeMovilesDbContext dbcontextRepuestos = new RepuestosDeMovilesDbContext();
            int currentRowHandle = gridViewArticulos.FocusedRowHandle;
            MyEntityModel.Articulo articulo = (MyEntityModel.Articulo)gridViewArticulos.GetRow(currentRowHandle);
            if (articulo != null)
            {
                gridControlPedidos.Invoke((MethodInvoker)(() => gridControlPedidos.DataSource = dbcontextRepuestos.L_PEDIDOS.Where(w => w.ARTICULO == articulo.Codigo.Trim()).OrderByDescending(o => o.CONTADOR).ToList()));
 //               gridControlPedidos.DataSource = dbcontextRepuestos.L_PEDIDOS.Where(w => w.ARTICULO == articulo.Codigo.Trim()).OrderByDescending(o => o.CONTADOR).ToList();
            }
            else
            {
                gridControlPedidos.Invoke((MethodInvoker)(() => gridControlPedidos.DataSource = null));
 //               gridControlPedidos.DataSource = null;
            }
        }

        private void pintarCompras()
        {
            ApplicationDbContextSql dbcontext = new ApplicationDbContextSql();
            int currentRowHandle = gridViewArticulos.FocusedRowHandle;
            MyEntityModel.Articulo articulo = (MyEntityModel.Articulo)gridViewArticulos.GetRow(currentRowHandle);
            if (articulo != null)
            {
                gridControlCompras.Invoke((MethodInvoker)(() => gridControlCompras.DataSource = dbcontext.Lineas.Where(w => w.ArticuloID == articulo.ArticuloID && w.Tipo.Contains("B")).OrderByDescending(o => o.Fecha).ToList()));
//                gridControlCompras.DataSource = dbcontext.Lineas.Where(w => w.ArticuloID == articulo.ArticuloID && w.Tipo.Contains("B")).OrderByDescending(o => o.Fecha).ToList();
            }
            else
            {
                gridControlCompras.Invoke((MethodInvoker)(() => gridControlCompras.DataSource = null));
 //               gridControlCompras.DataSource = null;
            }
        }

        private void pintarEnvios()
        {
            ApplicationDbContextSql dbcontext = new ApplicationDbContextSql();
            RepuestosDeMovilesDbContext dbcontextRepuestos = new RepuestosDeMovilesDbContext();
            int currentRowHandle = gridViewArticulos.FocusedRowHandle;
            MyEntityModel.Articulo articulo = (MyEntityModel.Articulo)gridViewArticulos.GetRow(currentRowHandle);
            if (articulo != null)
            {
                gridControlEnvios.Invoke((MethodInvoker)(() => gridControlEnvios.DataSource = dbcontextRepuestos.L_ENVIOS.Where(w => w.ARTICULO == articulo.Codigo.Trim()).OrderByDescending(o => o.FECHA).ToList()));
//                gridControlEnvios.DataSource = dbcontextRepuestos.L_ENVIOS.Where(w => w.ARTICULO == articulo.Codigo.Trim()).OrderByDescending(o => o.FECHA).ToList();
            }
            else
            {
                gridControlEnvios.Invoke((MethodInvoker)(() => gridControlEnvios.DataSource = null));
//                gridControlEnvios.DataSource = null;
            }
        }

        private void pintarRajotero()
        {
            MyEntityModel.Articulo row = (MyEntityModel.Articulo)gridViewArticulos.GetRow(gridViewArticulos.FocusedRowHandle);
            rajoteroArticulo1.CargarArticulo((string)row.Codigo, (string)row.Nombre);
            rajoteroArbolCategorias.product = rajoteroArticulo1.product;
        }

        private void PintarTabsArticulo(object sender)
        {
            string codigo = (string)gridViewArticulos.GetRowCellValue(gridViewArticulos.FocusedRowHandle, colCodigo);
            //if (layoutControlGroupEstadisticas.Visible)
            //{

            //    GridView view = sender as GridView;
            //    int currentRowHandle = view.FocusedRowHandle;
            //    MyEntityModel.Articulo row = (MyEntityModel.Articulo)view.GetRow(currentRowHandle);
            //    estadisticasVentasArticuloUserControl1.Pintar(row.ArticuloID);
            //}

            if (codigo == null)
                return;

            new Thread(new ThreadStart(pintarCompras)).Start();
            new Thread(new ThreadStart(pintarPedidos)).Start();
            new Thread(new ThreadStart(pintarEnvios)).Start();
            //           new Thread(new ThreadStart(pintarRajotero)).Start();
            pintarRajotero();
            if (codigo != null)
                new Thread(() => CargarImagenes(codigo.Trim())).Start();
            if (codigo != null)
                new Thread(() => ebayUserControl1.Cargar(codigo.Trim())).Start();

            if (layoutControlGroupVentas.Visible)
            {
                int NumeroLineas = 0;
                List<MyEntityModel.Linea> lineas = new List<MyEntityModel.Linea>();
                gridControlVentas.ForceInitialize();
                Application.DoEvents();
                GridView view = sender as GridView;
                int currentRowHandle = view.FocusedRowHandle;
                MyEntityModel.Articulo row = (MyEntityModel.Articulo)view.GetRow(currentRowHandle);

                MyEntityModel.Articulo articulo = ((ColumnView)sender).GetFocusedRow() as MyEntityModel.Articulo;
                var c = dataContextArticulos.Escandallos.Where(w => w.ArticuloID == articulo.ArticuloID).Count();
                if (c > 0)
                {
                    Debug.WriteLine("tiene Escandallos");
                    lineas = dataContextArticulos.Lineas.Where(w => w.ArticuloCompradoID == articulo.ArticuloID).ToList();
                    gridControlVentas.DataSource = lineas;
                    NumeroLineas = lineas.Count;
                }
                else
                {
                    if (articulo != null)
                    {
                        gridControlVentas.DataSource = dataContextArticulos.Lineas.Where(w => w.ArticuloID == row.ArticuloID).ToList();
                        NumeroLineas = dataContextArticulos.Lineas.Where(w => w.ArticuloID == row.ArticuloID).Count();
                    }
                    else
                    {
                        NumeroLineas = 0;
                        gridControlVentas.DataSource = null;
                    }
                }

                if ((LayoutControlVentasCargada == false) && (NumeroLineas > 0))
                {
                    gridViewVentas.PopulateColumns();
                    if (File.Exists("Layouts\\Articulos\\gridViewVentas.xml"))
                    {
                        gridViewVentas.RestoreLayoutFromXml("Layouts\\Articulos\\gridViewVentas.xml");
                    }
                    LayoutControlVentasCargada = true;
                }

                ventas7(row.ArticuloID);
                ventas30(row.ArticuloID);
                ventas(row.ArticuloID);
            }
            //if (layoutControlGroupImagenes.Visible)
            //{
            //    CargarImagenes(codigo);
            //}
            //if (layoutControlGroupEbay.Visible)
            //{
            //    ebayUserControl1.Cargar(codigo.Trim());
            //}

            //if (layoutControlGroupRajotero.Visible == true)
            //{
            //    MyEntityModel.ps_product model = dataContextRajotero.ps_product.Where(w => w.reference == codigo.Trim()).FirstOrDefault();
            //    if (model == null)   // si es un artículo nuevo
            //    {
            //        model = new MyEntityModel.ps_product();
            //        model.reference = codigo;
            //        var lang = new MyEntityModel.ps_product_lang();
            //        lang.name = (string)gridViewArticulos.GetRowCellValue(gridViewArticulos.FocusedRowHandle, colNombre);
            //        List<MyEntityModel.ps_product_lang> lista = new List<MyEntityModel.ps_product_lang>();
            //        lista.Add(lang);
            //        model.ps_product_lang = lista;
            //    }
            //    else
            //    {
            //        //               model = new MyEntityModel.ps_product();
            //        //               model.reference = codigo;
            //    }
            //    arbolCategoriasRajoteroUserControl.ps_product = model;
            //    int currentRowHandle = gridViewArticulos.FocusedRowHandle;
            //    MyEntityModel.Articulo articulo = (MyEntityModel.Articulo)gridViewArticulos.GetRow(currentRowHandle);
            //    if (articulo != null)
            //    {
            //        arbolCategoriasRajoteroUserControl.articulo = articulo;
            //    }
            //}


        }
        private void gridViewArticulos_Click(object sender, EventArgs e)
        {
            PintarTabsArticulo(sender);
        }


        private class CodigoArticulos
        {
            public  string codigo { get; set; }
            public string articulo { get; set; }
            public int rowHandle { get; set; }
        }
        private void simpleButtonLeerEbayTodos_Click(object sender, EventArgs e)
        {
            int i;
            List<CodigoArticulos> codigoArticulos = new List<CodigoArticulos>();
            simpleButtonLeerEbayTodos.Enabled = false;
            List<string> ListaTodosCodigos = new List<string>();
            List<string> ListaArticulos = new List<string>();
            MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
            for (i = 0; i < gridViewArticulos.DataRowCount; i++)
            {
                string codigo = (string)gridViewArticulos.GetRowCellValue(i, "Codigo");
                List<string> ListaCodigos = FuncionesEbay.fnListaCodigos(codigo);
                string CadenaIn = "";
                foreach (var c in ListaCodigos)
                {
                    CadenaIn += "'" + c + "'";
                }
                CadenaIn = CadenaIn.Replace("''", "','");
                string sql = string.Format("Select * from EBAY_SEGUIMIENTO where (articulo_mio in ({0}) or codigo in ({0})) and vendedor in ({1})", CadenaIn, Global.CuentasEbaySQL);
                var a = dbContext.Database.SqlQuery<MyEntityModel.EBAY_SEGUIMIENTO>(sql).ToList();
                foreach (MyEntityModel.EBAY_SEGUIMIENTO b in a)
                {
                    codigoArticulos.Add(new CodigoArticulos { codigo = codigo, articulo = b.ARTICULO, rowHandle = i });
                }
            }
            codigoArticulos = codigoArticulos.Distinct().ToList();
            gridViewArticulos.ClearSelection();
            Parallel.ForEach(codigoArticulos, new ParallelOptions { MaxDegreeOfParallelism = 4 }, ac =>
            {
                ItemType Item = MyEntityModel.FuncionesEbay.LeerArticuloEbay(ac.articulo);
                if ((Item.Quantity - Item.SellingStatus.QuantitySold) == 0)
                {
                    gridViewArticulos.SelectRow(ac.rowHandle);
                }
            });
            simpleButtonLeerEbayTodos.Enabled = true;
        }

        private int fnRowHandleCodigo(string codigo)
        {
            int rh = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
            for (int i = 0; i < gridViewArticulos.RowCount - 1; i++)
            {
                if ( gridViewArticulos.GetRowCellValue(i, "Codigo").ToString().Trim() == codigo)
                {
                    rh = i;
                    break;
                }
            }
            return rh;
        }



        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            for (int i = 0; i < gridViewArticulos.RowCount - 1; i++)
            {
                var a = gridViewArticulos.GetRowCellValue(i, "Codigo").ToString();
            }
        }

     

    

        private void checkEditNoDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            checkEditNoDisponibles.Enabled = false;
            WaitForm1 fr = new WaitForm1();
            fr.Show();
            DevExpress.XtraEditors.ProgressBarControl pb = (DevExpress.XtraEditors.ProgressBarControl)fr.Controls.Find("progressBarControl1", true)[0];
            pb.Properties.Maximum = gridViewArticulos.DataRowCount;
            if (checkEditNoDisponibles.Checked)
            {
                int i;
                simpleButtonLeerEbayTodos.Enabled = false;
                List<string> ListaTodosCodigos = new List<string>();
                List<string> ListaArticulos = new List<string>();
                MyEntityModel.RepuestosDeMovilesDbContext dbContext = new MyEntityModel.RepuestosDeMovilesDbContext();
                for (i = 0; i < gridViewArticulos.DataRowCount; i++)
                {
                    pb.Text = i.ToString();
                    Application.DoEvents();
                    string codigo = (string)gridViewArticulos.GetRowCellValue(i, "Codigo");
                    List<string> ListaCodigos = FuncionesEbay.fnListaCodigos(codigo);
                    string CadenaIn = "";
                    foreach (var c in ListaCodigos)
                    {
                        CadenaIn += "'" + c + "'";
                    }
                    CadenaIn = CadenaIn.Replace("''", "','");
                    string sql = string.Format("Select * from EBAY_SEGUIMIENTO where (articulo_mio in ({0}) or codigo in ({0})) and vendedor in ({1}) and (restocking = 'NO' or UNIDADES_DISPONIBLE < 1 )", CadenaIn, Global.CuentasEbaySQL);
                    var a = dbContext.Database.SqlQuery<MyEntityModel.EBAY_SEGUIMIENTO>(sql).ToList();
                    foreach (MyEntityModel.EBAY_SEGUIMIENTO b in a)
                    {
                        rowNoDisponibles.Add(i);
                    }
                }
            }
            else
                rowNoDisponibles.Clear();

            gridViewArticulos.LayoutChanged();
            checkEditNoDisponibles.Enabled = true;
            fr.Close();
        }

        private void gridViewArticulos_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (rowNoDisponibles.Where(w => w == e.RowHandle).Count() > 0)
            {
                e.Appearance.BackColor = Color.Orange;
            }
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }

        void ComoMostrarDescripcion(object sender, EventArgs e)
        {
            if (colNombre.ColumnEdit == null)
                colNombre.ColumnEdit = repositoryItemMemoEdit1;
            else
                colNombre.ColumnEdit = null;
        }
        private void gridViewArticulos_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                e.Menu.Items.Clear();

                int colId = e.HitInfo.Column.ColumnHandle;
                int rowId = e.HitInfo.RowHandle;
                DevExpress.Utils.Menu.DXMenuItem dxMenuItem;
                if (colNombre.ColumnEdit == null)
                {
                    dxMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Mostrar nombre completo", ComoMostrarDescripcion);
                    e.Menu.Items.Add(dxMenuItem);
                }
                else
                {
                    dxMenuItem = new DevExpress.Utils.Menu.DXMenuItem("Recortar nombre", ComoMostrarDescripcion);
                    e.Menu.Items.Add(dxMenuItem);
                }
             
            }
        }

        private void gridViewArticulos_DoubleClick(object sender, EventArgs e)
        {
            var h = gridViewArticulos.FocusedRowHandle;
            var id = gridViewArticulos.GetRowCellValue(h, colArticuloID);
            fTopRowIndex = gridViewArticulos.TopRowIndex;
            fFocusedRowHandle = gridViewArticulos.FocusedRowHandle;
            var form = new ArticulosEditar((int)id);
            form.ShowDialog(this); // if you need non-modal window
            LoadSource();
        }
    }
}
