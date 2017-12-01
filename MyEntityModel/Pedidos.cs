using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("L_PEDIDOS")]
    public partial class L_PEDIDOS
    {
        [Key]
        public int CONTADOR { get; set; }
        public int? ORDEN { get; set; }
        public int PEDIDO { get; set; }
        public DateTime? FECHA { get; set; }
        public string ARTICULO { get; set; }
        public int UNIDADES { get; set; }
        public int UNIDADES_ENVIADAS { get; set; }
        public DateTime? FECHA_ENVIO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string OBSERVACIONES_HUGO { get; set; }
        public decimal? PRECIO_RMB { get; set; }
        public string COMPRADO { get; set; }
        public string encargado_compra { get; set; }
        public string shop { get; set; }
        public DateTime? FECHA_PEDIDO { get; set; }
    }
}