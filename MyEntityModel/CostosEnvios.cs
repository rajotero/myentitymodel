using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    [System.ComponentModel.DataAnnotations.Schema.Table("COSTOS_ENVIOS_NOMBRES")]
    public partial class COSTOS_ENVIOS_NOMBRES
    {
        public int id { get; set; }
        public string nombre { get; set; }

    }

    [System.ComponentModel.DataAnnotations.Schema.Table("COSTOS_ENVIOS_PESOS")]
    public partial class COSTOS_ENVIOS_PESOS
    {
        public int id { get; set; }
        public int? id_nombre { get; set; }
        public int? peso_inicial { get; set; }
        public int? peso_final { get; set; }
        public decimal? precio { get; set; }

    }
}
