using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    public class PharmacyScheduleOutput
    {
        /// <summary>
        /// Indica el dia de la semana
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Indica el horari ode apertura 
        /// </summary>
        public string OpeningTime { get; set; }

        /// <summary>
        /// Indica el horario de cierrre
        /// </summary>
        public string  ClosingTime { get; set; }
    }
}
