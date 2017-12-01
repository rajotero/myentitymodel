using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyEntityModel;
using DevExpress.XtraTreeList.Nodes;
using Bukimedia.PrestaSharp.Factories;

namespace Gestion_WF.Rajotero
{
    public partial class RajoteroArtiulo : UserControl
    {
        string _BaseUrl = "http://www.rajotero.es/tienda/api";
        string _Account = "JSLJEV1FQYWDQWQ6XSR43WNWH4H6RMCD";
        string _Password = "";
        RajoteroDbContext RajoteroDbcontext = new MyEntityModel.RajoteroDbContext();
        public Bukimedia.PrestaSharp.Entities.product product;
        public RajoteroArtiulo()
        {
            InitializeComponent();
        }
        public void CargarArticulo(string reference, string titulo = "")
        {
            var PF = new ProductFactory(_BaseUrl, _Account, _Password);
            product = prestashop.CargarProductoPrestashopReferencia(reference);
            if (product != null)
            {
                textEditReferencia.Text = product.reference;
                textEditTitulo.Text = product.name[0].Value;
                memoEditDescripction.Text = product.description[0].Value;
                memoEditDescripction_short.Text =  product.description_short[0].Value;
                simpleButtonGrabar.Text = "Grabar";
            }
            else
            {
                Bukimedia.PrestaSharp.Entities.AuxEntities.language Lenguaje = new Bukimedia.PrestaSharp.Entities.AuxEntities.language();
                Lenguaje.id = 1;
                product = new Bukimedia.PrestaSharp.Entities.product();
                product.reference = reference;
                textEditTitulo.Text = "";
                simpleButtonGrabar.Text = "Crear";

            }

            //model = RajoteroDbcontext.ps_product.Where(w => w.reference == reference).FirstOrDefault();
            //var model_lang = RajoteroDbcontext.ps_lang.ToList();
            //repositoryItemLookUpEdit1.DataSource = model_lang;
            //textEditReferencia.Text = reference;
            //if (model != null)
            //{
            //    gridControl.DataSource = model.ps_product_lang;
            //}
            //else
            //{
            //    model = new ps_product();
            //    var model_pd_product_lang = new ps_product_lang();
            //    model_pd_product_lang.id_lang = RajoteroDbcontext.ps_lang.FirstOrDefault().id_lang;
            //    model_pd_product_lang.name = titulo;
            //    model.ps_product_lang = new List<ps_product_lang>();
            //    model.ps_product_lang.Add(model_pd_product_lang);
            //    gridControl.DataSource = model.ps_product_lang;
            //}
        }

        private void layoutView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            RajoteroDbcontext.SaveChanges();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //var parentForm = this.Parent;
            //RajoteroArbolCategorias rajoteroArbolCategorias = parentForm.Controls.Find("rajoteroArbolCategorias", false).FirstOrDefault() as RajoteroArbolCategorias;
            //DevExpress.XtraTreeList.TreeList tree = rajoteroArbolCategorias.Controls.Find("treeList", false).FirstOrDefault() as DevExpress.XtraTreeList.TreeList;
            //List<TreeListNode> nodes = tree.GetAllCheckedNodes();

            //model.id_category_default = nodes[0].Id;
            //model.id_supplier = 0;
            //model.id_manufacturer = 0;
            //model.id_shop_default = 1;
            //model.id_tax_rules_group = 1;
            //model.on_sale = false;
            //model.online_only = false;
            //model.ecotax = 0;
            //model.quantity = 0;
            //model.minimal_quantity = 1;
            //model.price = 12;
            //model.wholesale_price = 0;
            //model.unit_price_ratio = 0;
            //model.additional_shipping_cost = 0;
            //model.width = 0;
            //model.height = 0;
            //model.depth = 0;
            //model.weight = 0;
            //model.out_of_stock = 2;
            //model.quantity_discount = false;
            //model.customizable = 0;
            //model.uploadable_files = 0;
            //model.text_fields = 0;
            //model.active = true;
            //model.redirect_type = "404";
            //model.id_type_redirected = 0;
            //model.available_for_order = true;
            //model.available_date = DateTime.Now;
            //model.show_condition = false;
            //model.condition = "new";
            //model.show_price = true;
            //model.indexed = true;
            //model.visibility = "both";
            //model.cache_is_pack = false;
            //model.cache_has_attachments = false;
            //model.is_virtual = false;
            //model.cache_default_attribute = 0;
            //model.date_add = DateTime.Now;
            //model.date_upd = DateTime.Now;
            //model.advanced_stock_management = false;
            //model.pack_stock_type = 3;
            //model.state = 1;
            //MyEntityModel.ps_product_lang model_lang = new ps_product_lang();
            ////            model_lang.
            ////            model.ps_product_lang.Add()



            //RajoteroDbcontext.ps_product.Add(model);
            //RajoteroDbcontext.SaveChanges();
        }

        private void memoEditDescripction_short_EditValueChanged(object sender, EventArgs e)
        {


        }
    }
}
