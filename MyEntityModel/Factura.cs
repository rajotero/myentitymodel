using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("Lineas")]
    public class Linea
    {
        public int LineaID { get; set; }
        public int Numero { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public int ArticuloID { get; set; }
        public int? CabeceraID { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        [Column(TypeName = "money")]
        public decimal TipoIva { get; set; }
        [Column(TypeName = "money")]
        public decimal TipoRecargo { get; set; }
        public string TituloComprado { get; set; }
        public string Historial { get; set; }
        public virtual Cabecera Cabecera { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [Index]
        [MaxLength(11)]
        [Column(TypeName = "varchar")]
        public string ArticuloComprado { get; set; }
        public int UnidadesArticuloComprado { get; set; }
        public int? ArticuloCompradoID { get; set; }
    }

    [Table("Cabeceras")]
    public class Cabecera
    {
        public int CabeceraID { get; set; }
        [Index("IX_TipoNumero", 1)]
        [MaxLength(3)]
        [Column(TypeName = "varchar")]
        public string Tipo { get; set; }
        [Index("IX_TipoNumero", 2)]
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
        public int ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public int Paquetes { get; set; }
        [Column(TypeName = "money")]
        public decimal BaseImponible { get; set; }
        [Column(TypeName = "money")]
        public decimal TipoIva { get; set; }
        [Column(TypeName = "money")]
        public decimal TipoRecargo { get; set; }
        [Column(TypeName = "money")]
        public decimal ImporteIva { get; set; }
        [Column(TypeName = "money")]
        public decimal ImporteRecargo { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        [Column(TypeName = "money")]
        public decimal TipoRetencion { get; set; }
        [Column(TypeName = "money")]
        public decimal ImporteRetencion { get; set; }
        public String Usuario { get; set; }
        public int FormaPagoID { get; set; }
        public int FormaEnvioID { get; set; }
        public SiNo EtiquetaSeurImpresa { get; set; }
        public int Peso { get; set; }
        [Column(TypeName = "money")]
        public decimal Reembolso { get; set; }
        public SiNo DocumentoImpreso { get; set; }
        public string Historial { get; set; }
        [Column(TypeName = "text")]
        public string Observaciones { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<Linea> Lineas { get; set; }
        public virtual Cliente cliente { get; set; }

        //    public int Peso_ { get; set; }


    }
}
