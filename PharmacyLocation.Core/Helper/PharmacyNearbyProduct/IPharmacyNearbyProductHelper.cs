using PharmacyLocation.Core.Helper.PharmacyNearbyProduct;
using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Provider.PharmacyNearbyProduct
{
    /// <summary>
    /// Helper que ayuda al procesamiento de la farmacia mas cercana de las que tiene el producto en base a la ubicacion actual del usuario
    /// </summary>
    public interface IPharmacyNearbyProductHelper
    {
        /// <summary>
        /// Con las farmacias y la ubicacion del usuario calcula la farmacias mas cercanas que tiene el producto
        /// </summary>
        /// <param name="pharmacyNearbyProductInput"></param>
        /// <returns></returns>
        Task<List<PharmacyNearbyProductOutput>> GetPharmacyNearbyProduct(PharmacyNearbyProductInput pharmacyNearbyProductInput);
    }
}
