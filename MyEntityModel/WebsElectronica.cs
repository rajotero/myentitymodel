using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("WebsElectronicaPaginas")]
    public class WebsElectronicaPagina
    {
        public int WebsElectronicaPaginaID { get; set; }
        [Index("UltIndex", IsUnique = true)]
        [MaxLength(254)]
        [Column(TypeName = "varchar")]
        public string Url { get; set; }
        public string Obs { get; set; }
        public string Imagen { get; set; }
        public bool Seleccionada { get; set; }
        public string web { get; set; }
    }

    [Table("WebsElectronicaArticulos")]
    public class WebsElectronicaArticulo
    {
        public int WebsElectronicaArticuloID { get; set; }
        public int WebsElectronicaPaginaID { get; set; }
        [Index(IsUnique = true)]
        [StringLength(15)]
        public string Codigo { get; set; }
        public string url { get; set; }
        public string imagen { get; set; }
        public string titulo { get; set; }
        public string TituloNuestro { get; set; }
        public string web { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        public int ArticuloID { get; set; }
        public string ArticuloCodigo { get; set; }
        public bool Pedir { get; set; }
        public int TiendaHugoID { get; set; }
        [Column(TypeName = "money")]
        public decimal Rmb { get; set; }
        public int Unidades { get; set; }
        public int Vendidos { get; set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
        public Nullable<DateTime> FechaModificacion { get; set; }

    }

    [Table("TiendasHugo")]
    public class TiendaHugo
    {

        public int TiendaHugoID { get; set; }
        public string Nombre { get; set; }


    }
}
