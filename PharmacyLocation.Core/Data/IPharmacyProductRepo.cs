using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    /// <summary>
    /// Acceso a datos a la tabla de <see cref="PharmacyProduct"/>
    /// </summary>
    public interface IPharmacyProductRepo : IBaseRepo<PharmacyProduct>
    {
        /// <summary>
        /// Obtengo el listado de productos  farmacia donde los productos sean los que envio
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<PharmacyProduct>> GetPharmacyProductsByIdAsync(string productId);
    }
}
