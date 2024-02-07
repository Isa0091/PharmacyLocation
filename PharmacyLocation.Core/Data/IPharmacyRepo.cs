using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    /// <summary>
    /// Acceso a datos a la tabla de <see cref="Pharmacy"/>
    /// </summary>
    public interface IPharmacyRepo : IBaseRepo<Pharmacy>
    {
        /// <summary>
        /// Retorna un lsitado de farmacias
        /// </summary>
        /// <param name="pharmaciesIds"></param>
        /// <returns></returns>
        Task<List<Pharmacy>> GetPharmacyAsync(List<string> pharmaciesIds);
    }
}
