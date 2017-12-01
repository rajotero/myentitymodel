using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntityModel
{
    public enum SiNo
    {
        No, Si
    }

    public enum EnumTiendas
    { FO, MO, RM, WP }

    public enum ViajesIDs
    {
        [Display(Name = "Viaje Estados Unidos 2017")]
        EEUU17
    }
}
