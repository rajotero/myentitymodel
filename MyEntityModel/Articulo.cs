using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("PRUEBA")]

    public class Prueba
    {
        [Key]
        public string NICK { get; set; }
        public string NOMBRE { get; set; }
        //       public int a { get; set; }

    }

    [Table("Articulos")]
    public class Articulo
    {

        public int ArticuloID { get; set; }
        public string Nombre { get; set; }
        public int TipoArticuloID { get; set; }
        public int IvaID { get; set; }
        public int RecargoID { get; set; }
        public string NombreIngles { get; set; }

        public int PesoNeto { get; set; }
        public int PesoBruto { get; set; }

        [MaxLength(11)]
        [Column(TypeName = "varchar")]
        [Index]
        public string Codigo { get; set; }

        public SiNo Activo { get; set; }

        [Column(TypeName = "text")]
        public string Observaciones { get; set; }

        [Column(TypeName = "text")]
        public string ObservacionesProximaCompra { get; set; }

        public int UnidadMinimaDeVenta { get; set; }

        [Column(TypeName = "money")]
        public decimal Costo { get; set; }

        [Column(TypeName = "money")]
        public decimal CostoRmb { get; set; }

        public DateTime FechaModificacion { get; set; }
        public string URL { get; set; }
        public int? VendidosTreinta { get; set; }
        public int? VendidosSiete { get; set; }
        public int? Vendidos { get; set; }
        public int? comprados { get; set; }
        public string URLSeguimientoEbay { get; set; }
        //public virtual ICollection<GrupoImagen> GruposImagenes { get; set; }
        public virtual ICollection<Escandallo> Escandallos { get; set; }
        public virtual ICollection<Linea> Lineas { get; set; }
        public int test { get; set; }
    }

    [Table("GruposImagenes")]
    public class GrupoImagen
    {

        public int GrupoImagenId { get; set; }
        public string Nombre { get; set; }

        public virtual Articulo Articulo { get; set; }

        public virtual ICollection<ImagenesDeUnGrupo> ImagenesDeUnGrupos { get; set; }
    }

    [Table("ImagenesDeUnGrupo")]
    public class ImagenesDeUnGrupo
    {
        public int ImagenesDeUnGrupoID { get; set; }
        public string Url { get; set; }

        public virtual GrupoImagen GrupoImagen { get; set; }
    }

    public class AsociacionArticulo
    {

        public int AsociacionArticuloID { get; set; }
        public EnumTiendas Tienda { get; set; }
        public int ArticuloID { get; set; }
        public int TiendaProductsID { get; set; }
    }

    [Table("Escandallo")]
    public class Escandallo
    {

        public int EscandalloID { get; set; }
        [Index]
        public int ArticuloID { get; set; }
        [Index]
        public int DetalleID { get; set; }
        public SiNo Imprimir { get; set; }
        public SiNo Precio { get; set; }
        public int Unidades { get; set; }
        public virtual Articulo Articulo { get; set; }
        //        public virtual Articulo ArticuloDetalle { get; set; }


    }

    public class UrlHugo
    {
        public string codigo { get; set; }
        public string url { get; set; }
    }

    [Table("TipoArticulo")]
    public class TipoArticulo
    {

        public int TipoArticuloID { get; set; }
        public string Nombre { get; set; }

    }

}
