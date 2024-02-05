using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Helper.PharmacyNearbyProduct
{
    /// <summary>
    /// Datos para determinar cual farmacia es la mas cercana
    /// </summary>
    public class PharmacyNearbyProductInput
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PharmacyOutput> Pharmacies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LocationVo UserLocation { get; set; }
    }
}
