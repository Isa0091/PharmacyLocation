using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    /// <summary>
    /// Acceso a datos a la tabla de <see cref="FavoriteUserProduct"/>
    /// </summary>
    public interface IFavoriteUserProductRepo :  IBaseRepo<FavoriteUserProduct>
    {
        /// <summary>
        /// Ontengo la opcion de producto favorito por usuario y producto
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<FavoriteUserProduct?> GetFavoriteUserProductByIdAsync(string userId, string productId);

        /// <summary>
        /// Obtengo los productos favoritos de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<FavoriteUserProduct>> GetFavoritesUserProductsAsync(string userId);
    }
}
