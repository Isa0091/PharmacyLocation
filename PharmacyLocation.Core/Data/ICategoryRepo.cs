using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Data
{
    public interface ICategoryRepo: IBaseRepo<Category>
    {
        /// <summary>
        /// Obtengo un lsitado de categorias por su identificador
        /// </summary>
        /// <param name="categoriesIds"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategoriesAsync(List<string> categoriesIds);
    }
}
