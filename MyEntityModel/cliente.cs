using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(11)]
        [Column(TypeName = "varchar")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public string Cif { get; set; }
        [Column(TypeName = "money")]
        public decimal Retencion { get; set; }
        public SiNo Iva { get; set; }
        public SiNo Recargo { get; set; }
        public string Pais { get; set; }
        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string CodigoPostal { get; set; }
        [Column(TypeName = "text")]
        public string Observaciones { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
