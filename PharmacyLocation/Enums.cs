using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyLocation
{
    public enum WeekDay
    {
        [Display(Name = "Lunes")]
        Monday = 1,
        [Display(Name = "Martes")]
        Tuesday = 2,
        [Display(Name = "Miércoles")]
        Wednesday = 3,
        [Display(Name = "Jueves")]
        Thursday = 4,
        [Display(Name = "Viernes")]
        Friday = 5,
        [Display(Name = "Sábado")]
        Saturday = 6,
        [Display(Name = "Domingo")]
        Sunday = 7
    }
}
