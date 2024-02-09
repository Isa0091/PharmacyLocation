using PharmacyLocation.Outputs;
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
        /// <summary>
        /// Obtengo un listado paginado de productos
        /// </summary>
        /// <param name="nameContains"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        Task<PaginatedListOutput<Product>> GetPaginatedProductsAsync(string? nameContains, int page, int itemsPerPage);

        /// <summary>
        /// Obtengo un producto por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetByIdAsync(string id);

        /// <summary>
        /// Obtengo los productos por sus identificadores
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<Product>> GetByIdsAsync(List<string> ids);
    }
}
