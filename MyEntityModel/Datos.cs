using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [Table("Datos")]
    public class Datos
    {
        public int DatosID { get; set; }
        public DateTime? FechaActualizacionTotalesArticulo { get; set; }
        public DateTime? FechaActualizacionEbay { get; set; }
    }
}
