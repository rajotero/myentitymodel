using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public class Viaje
    {
        public int ViajeID { get; set; }
        public ViajesIDs viajeIDs { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int tipo { get; set; }
        public int AllDay { get; set; }
        public string Location { get; set; }
        public int status { get; set; }
        public int label { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string ReminderInfo { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string RecurrenceInfo { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string CustomField1 { get; set; }
        public int ResourceID { get; set; }
    }


    [Table("ViajeResources")]
    public class ViajeResources
    {
        public int ViajeResourcesID { get; set; }
        public string ResourceName { get; set; }
        public int? Color { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Column(TypeName = "ntext")]
        [MaxLength]
        public string CustomField1 { get; set; }
    }
}
