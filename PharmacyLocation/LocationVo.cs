using Isa0091.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation
{
    /// <summary>
    /// Datos de locacion 
    /// </summary>
    public class LocationVo : IValidatedValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Presicion { get; set; }

        public void IsValid()
        {

        }
    }
}
