using DevExpress.XtraBars;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using Gestion_WF.Amazon;
using Gestion_WF.Articulos;
using Gestion_WF.Ebay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_WF
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
            Size = new Size(1936, 1056);
            ribbonControl.Minimized = true;
            System.IO.Directory.CreateDirectory("Layouts\\Articulos");
            System.IO.Directory.CreateDirectory("Layouts\\ArticulosPedir");
            System.IO.Directory.CreateDirectory("Layouts\\Clientes");
            System.IO.Directory.CreateDirectory("Layouts\\EbayPublicar\\");
            System.IO.Directory.CreateDirectory("Layouts\\EbaySeguimiento\\");
            System.IO.Directory.CreateDirectory("Layouts\\EbayUserControl\\");
            System.IO.Directory.CreateDirectory("Layouts\\EbayGetOrders\\");
            System.IO.Directory.CreateDirectory("Layouts\\LeerPedidosAmazon\\");
            //            Global.textoEstado = barStaticItemEstado;
            //            Global.textoEstado.Caption = "";
        }

        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs E = (ClosePageButtonEventArgs)e;
            xtraTabControl.TabPages.Remove((XtraTabPage)E.Page);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barStaticItemArticulo.Enabled = false;
            var page = new DevExpress.XtraTab.XtraTabPage();
            xtraTabControl.TabPages.Add(page);
            page.Text = "Artículos";
            var cliente = new ArticulosUserControl();
            page.Controls.Add(cliente);
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
            barStaticItemArticulo.Enabled = true;
        }

        private void barButtonItemImportarFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var page = new DevExpress.XtraTab.XtraTabPage();
            xtraTabControl.TabPages.Add(page);
            page.Text = "Importar Factura";
            var cliente = new ImportarFacturaEbayUserControl();
            page.Controls.Add(cliente);
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
            
        }

        private void barButtonItemLeerPedidosEbay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var page = new DevExpress.XtraTab.XtraTabPage();
            xtraTabControl.TabPages.Add(page);
            page.Text = "Leer Ebay";
            var cliente = new GetOrdersUserControl();
            page.Controls.Add(cliente);
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
        }

        private void barButtonLeerPedidosAmazon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var page = new DevExpress.XtraTab.XtraTabPage();
            xtraTabControl.TabPages.Add(page);
            page.Text = "Leer Pedidos Amazon";
            var cliente = new LeerPedidosAmazonUserControl();
            page.Controls.Add(cliente);
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
            cliente.main = this;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ribbonStatusBar4_Click(object sender, EventArgs e)
        {

        }
    }

    static class Global
    {
        private static string _globalVar = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
        public static string TiposVentas = "ACD";
        public static string TiposVentasSQL = "'A','C','D'";

        public static string CuentasEbaySQL = "'rajotero','garfo_es','ofertasparati'";

        public static  List<string> CuentasAmazon = new List<string> { "Red_Planet" };

        public static string connectionstringInterbase =    "DriverName=Interbase;Database=" + "192.168.1.250:/datos/2007.gdb" + ";User_Name=" + "SYSDBA" + ";Password=" + "masterkey"+
                                                            ";SQLDialect=3;MetaDataAssemblyLoader=Borland.Data.TDBXInterbaseMetaDataCommandFactory,Borland.Data.DbxReadOnlyMetaData,Version=11.0.5000.0,Culture=neutral,"+
                                                            "PublicKeyToken=91d62ebb5b0d1b1b;GetDriverFunc=getSQLDriverINTERBASE;LibraryName=dbxint30.dll;VendorLib=GDS32.DLL";
    }
}
