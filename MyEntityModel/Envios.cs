using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("L_ENVIOS")]
    public partial class L_ENVIOS
    {
        [Key]
        public int COUNTER { get; set; }
        public string ARTICULO { get; set; }
        public decimal? UNIDADES { get; set; }
        public decimal? PESO { get; set; }
        public int? CABECERA { get; set; }
        public DateTime? FECHA { get; set; }
        public string nombre { get; set; }
        public decimal? PRECIO_RMB { get; set; }
        public decimal? ENVIO_UNIDAD_RMB { get; set; }
        public int? CONTADOR { get; set; }
        public decimal? PESO_TOTAL { get; set; }
        public decimal? ENVIO_TODO { get; set; }
        public decimal? COSTO_EUR_CHINA { get; set; }
        public decimal? ADUANA_UNIDAD { get; set; }
        public decimal? COSTO_EUR { get; set; }
        public decimal? PRECIO_0 { get; set; }
        public decimal? PRECIO_1 { get; set; }
        public decimal? PRECIO_2 { get; set; }
        public string WEB { get; set; }
        public string EBAY { get; set; }
        public decimal? COSTO_ANTERIOR { get; set; }
        public int? SI_WEB { get; set; }
        public int? SI_EBAY { get; set; }
        public decimal? tienda_1 { get; set; }
        public decimal? tienda_2 { get; set; }
        public decimal? CALCULADO_1 { get; set; }
        public decimal? CALCULADO_2 { get; set; }
        public string CODIGO_TIENDA { get; set; }
        public int? COLOR { get; set; }

    }
}
