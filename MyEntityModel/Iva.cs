using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("Iva")]
    public class Iva
    {
        public int IvaID { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName = "Money")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal Tipo { get; set; }
    }

    [Table("Recargo")]
    public class Recargo
    {
        public int RecargoID { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName = "Money")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal Tipo { get; set; }
    }
    [Table("Retencion")]
    public class Retencion
    {
        public int RetencionID { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName = "Money")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal Tipo { get; set; }
    }
}
