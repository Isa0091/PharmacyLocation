using Isa0091.Domain.Core.Model;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation
{
    public class PharmacySchedule : Entity
    {
        /// <summary>
        /// Indica el dia de la semana
        /// </summary>
        public WeekDay Day { get; set; }

        /// <summary>
        /// Indica el horari ode apertura 
        /// </summary>
        public TimeSpan OpeningTime { get; set; }

        /// <summary>
        /// Indica el horario de cierrre
        /// </summary>
        public TimeSpan ClosingTime { get; set; }

        /// <summary>
        /// Para la foranea
        /// </summary>
        private string PharmacyId { get; set; }

        /// <summary>
        /// Para la foranea
        /// </summary>
        private Pharmacy Pharmacy { get; set; }
    }
}
