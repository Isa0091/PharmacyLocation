using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    /// <summary>
    /// Acceso a datos a la tabla de <see cref="Product"/>
    /// </summary>
    public interface IProductRepo : IBaseRepo<Product>
    {
    }
}
