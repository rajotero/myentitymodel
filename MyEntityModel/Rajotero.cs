using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public class RajoteroDbContext : DbContext
    {
        public RajoteroDbContext()
           : base("RajoteroEntities")
        {
            Database.SetInitializer<RajoteroDbContext>(null);
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 5000 * 60; // value in seconds
        }
        public System.Data.Entity.DbSet<MyEntityModel.ps_product> ps_product { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ps_product_lang> ps_products_lang { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ps_group_lang> ps_groups_lang { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ps_category> ps_category { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ps_category_lang> ps_category_lang { get; set; }
        public System.Data.Entity.DbSet<MyEntityModel.ps_lang> ps_lang { get; set; }

        public System.Data.Entity.DbSet<MyEntityModel.ps_category_product> ps_category_product { get; set; }

    }

    public static class RajoteroController
    {
        public static RajoteroDbContext dbContext
        {
            get
            {
                return new MyEntityModel.RajoteroDbContext();
            }
        }
        public static IEnumerable<category_tree> ArbolCategorias(int id_lang)
        {
            var sql = string.Format("Select * from ps_category C,ps_category_lang CL where C.id_category = CL.id_category and CL.id_lang ={0} ORDER BY C.position ", id_lang);
            var AmazonEnVentaList = dbContext.Database.SqlQuery<category_tree>(sql).ToList();// dbRepuestos.AmazonEnVenta.SqlQuery(sql).ToList<AmazonEnVenta>();
            return AmazonEnVentaList;
        }
    }

    [Table("ps_category_product")]
    public partial class ps_category_product
    {
        [Key]
        public long id_category { get; set; }
        public long id_product { get; set; }
        public long position { get; set; }
    }

    [Table("ps_lang")]
    public partial class ps_lang
    {
        [Key]
        public long id_lang { get; set; }
        public string name { get; set; }
        public Boolean active { get; set; }
        public string iso_code { get; set; }
        public string language_code { get; set; }
        public string locale { get; set; }
        public string date_format_lite { get; set; }
        public string date_format_full { get; set; }
        public Boolean is_rtl { get; set; }

    }

    [Table("ps_group_lang")]
    public partial class ps_group_lang
    {
        [Key]
        public int id_group { get; set; }
        public int id_lang { get; set; }
        public string name { get; set; }

    }

    [Table("ps_product_lang")]
    public partial class ps_product_lang
    {
        [Key, Column(Order = 0)]
        public long id_product { get; set; }
        [Key, Column(Order = 1)]
        public long id_shop { get; set; }
        [Key, Column(Order = 2)]
        public long id_lang { get; set; }
        public string description { get; set; }
        public string description_short { get; set; }
        public string link_rewrite { get; set; }
        public string meta_description { get; set; }
        public string meta_keywords { get; set; }
        public string meta_title { get; set; }
        public string name { get; set; }
        public string available_now { get; set; }
        public string available_later { get; set; }
        public virtual ps_product ps_product { get; set; }
    }

    [Table("ps_product")]
    public partial class ps_product
    {
        [Key]
        public int id_product { get; set; }
        public long id_supplier { get; set; }
        public long id_manufacturer { get; set; }
        public long id_category_default { get; set; }
        public long id_shop_default { get; set; }
        public long id_tax_rules_group { get; set; }
        public Boolean on_sale { get; set; }
        public Boolean online_only { get; set; }
        public string ean13 { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public decimal ecotax { get; set; }
        public long quantity { get; set; }
        public long minimal_quantity { get; set; }
        public decimal price { get; set; }
        public decimal wholesale_price { get; set; }
        public string unity { get; set; }
        public decimal unit_price_ratio { get; set; }
        public decimal additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal depth { get; set; }
        public decimal weight { get; set; }
        public long out_of_stock { get; set; }
        public Boolean quantity_discount { get; set; }
        public int customizable { get; set; }
        public int uploadable_files { get; set; }
        public int text_fields { get; set; }
        public Boolean active { get; set; }
        public string redirect_type { get; set; }
        public long id_type_redirected { get; set; }
        public Boolean available_for_order { get; set; }
        public DateTime available_date { get; set; }
        public Boolean show_condition { get; set; }
        public string condition { get; set; }
        public Boolean show_price { get; set; }
        public Boolean indexed { get; set; }
        public string visibility { get; set; }
        public Boolean cache_is_pack { get; set; }
        public Boolean cache_has_attachments { get; set; }
        public Boolean is_virtual { get; set; }
        public long cache_default_attribute { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public Boolean advanced_stock_management { get; set; }
        public long pack_stock_type { get; set; }
        public long state { get; set; }
        public virtual ICollection<ps_product_lang> ps_product_lang { get; set; }
    }
    [Table("ps_product_shop")]
    public partial class ps_product_shop
    {
        [Key]
        public long product_id { get; set; }
        public long id_supplier { get; set; }
        public long id_manufacturer { get; set; }
        public long id_category_default { get; set; }
        public long id_shop_default { get; set; }
        public long id_tax_rules_group { get; set; }
        public Boolean on_sale { get; set; }
        public Boolean online_only { get; set; }
        public string ean13 { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public decimal ecotax { get; set; }
        public long quantity { get; set; }
        public long minimal_quantity { get; set; }
        public decimal price { get; set; }
        public decimal wholesale_price { get; set; }
        public string unity { get; set; }
        public decimal unit_price_ratio { get; set; }
        public decimal additional_shipping_cost { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public decimal width { get; set; }
        public decimal height { get; set; }
        public decimal depth { get; set; }
        public decimal weight { get; set; }
        public long out_of_stock { get; set; }
        public Boolean quantity_discount { get; set; }
        public int customizable { get; set; }
        public int uploadable_files { get; set; }
        public int text_fields { get; set; }
        public Boolean active { get; set; }
        public string redirect_type { get; set; }
        public long id_type_redirected { get; set; }
        public Boolean available_for_order { get; set; }
        public DateTime available_date { get; set; }
        public Boolean show_condition { get; set; }
        public string condition { get; set; }
        public Boolean show_price { get; set; }
        public Boolean indexed { get; set; }
        public string visibility { get; set; }
        public Boolean cache_is_pack { get; set; }
        public Boolean cache_has_attachments { get; set; }
        public Boolean is_virtual { get; set; }
        public long cache_default_attribute { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public Boolean advanced_stock_management { get; set; }
        public long pack_stock_type { get; set; }
        public long state { get; set; }
    }

    [Table("ps_stock_available")]
    public partial class ps_stock_available
    {
        [Key]
        public long id_stock_available { get; set; }
        public long id_product { get; set; }
        public long id_product_attribute { get; set; }
        public long id_shop { get; set; }
        public long id_shop_group { get; set; }
        public long quantity { get; set; }
        public Boolean depends_on_stock { get; set; }
        public Boolean out_of_stock { get; set; }

    }

    [Table("ps_category_lang")]
    public partial class ps_category_lang
    {
        [Key, Column(Order = 0)]
        public long id_category { get; set; }
        [Key, Column(Order = 1)]
        public long id_shop { get; set; }
        [Key, Column(Order = 2)]
        public long id_lang { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link_rewrite { get; set; }
        public string meta_title { get; set; }
        public string meta_keywords { get; set; }
        public string meta_description { get; set; }
        public virtual ps_category ps_category { get; set; }
    }

    [Table("ps_category")]
    public partial class ps_category
    {
        [Key]
        public long id_category { get; set; }
        public long id_parent { get; set; }
        public long id_shop_default { get; set; }
        public int level_depth { get; set; }
        public long nleft { get; set; }
        public long nright { get; set; }
        public bool active { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public long position { get; set; }
        public bool is_root_category { get; set; }
        public virtual ICollection<ps_category_lang> ps_category_langs { get; set; }
    }


    public partial class category_tree
    {
        [Key]
        public long id_category { get; set; }
        public long id_parent { get; set; }
        public long id_shop_default { get; set; }
        public int level_depth { get; set; }
        public long nleft { get; set; }
        public long nright { get; set; }
        public bool active { get; set; }
        public DateTime date_add { get; set; }
        public DateTime date_upd { get; set; }
        public long position { get; set; }
        public bool is_root_category { get; set; }
        public long id_shop { get; set; }
        public long id_lang { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link_rewrite { get; set; }
        public string meta_title { get; set; }
        public string meta_keywords { get; set; }
        public string meta_description { get; set; }

    }
}
