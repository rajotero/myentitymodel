using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public class AmazonPeso
    {
        public int ArticuloID { get; set; }
        public int Peso { get; set; }
    }
    public class AmazonEnVenta
    {
        public int id { get; set; }
        public string seller_sku { get; set; }
        public string vendedor { get; set; }
        public string item_name { get; set; }
        public int unidades_disponibles { get; set; }
        public string restocking { get; set; }
        public int ArticuloID { get; set; }
        public int Peso { get; set; }

    }
    [Table("AMAZON_SEGUIMIENTO")]
    public class AMAZON_SEGUIMIENTO
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string Cuenta { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public string listing_id { get; set; }
        public string seller_sku { get; set; }
        public decimal? price { get; set; }
        public int? quantity { get; set; }
        public string open_date { get; set; }
        public string image_url { get; set; }
        public string item_is_marketplace { get; set; }
        public string product_id_type { get; set; }
        public string zshop_shipping_fee { get; set; }
        public string item_note { get; set; }
        public string item_condition { get; set; }
        public string zshop_category1 { get; set; }
        public string zshop_browse_path { get; set; }
        public string zshop_storefront_feature { get; set; }
        public string asin1 { get; set; }
        public string asin2 { get; set; }
        public string asin3 { get; set; }
        public string will_ship_internationally { get; set; }
        public string expedited_shipping { get; set; }
        public string zshop_boldface { get; set; }
        public string product_id { get; set; }
        public string bid_for_featured_placement { get; set; }
        public string add_delete { get; set; }
        public string pending_quantity { get; set; }
        public string fulfillment_channel { get; set; }
        public string vendedor { get; set; }
        public string merchant_shipping_group { get; set; }
        public decimal? comision { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public string restocking { get; set; }
        public int? unidades_disponibles { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha_Descripcion { get; set; }
        public string Finalizado { get; set; }
        public DateTime? Fecha_Fologar { get; set; }
        public int? ArticuloID { get; set; }
    }
}
