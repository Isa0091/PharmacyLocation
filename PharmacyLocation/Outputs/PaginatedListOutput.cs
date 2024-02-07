using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    /// <summary>
    /// Datos necesarios para representar listados paginados
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PaginatedListOutput<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalItemCount"></param>
        /// <param name="curentPage"></param>
        /// <param name="itemsPerPage"></param>
        public PaginatedListOutput(List<TEntity> items, int totalItemCount, int curentPage, int itemsPerPage)
        {
            Items = items;
            TotalItemCount = totalItemCount;
            CurentPage = curentPage;
            ItemsPerPage = itemsPerPage;
            TotalPageCount = (int)Math.Ceiling((double)TotalItemCount / ItemsPerPage);
        }

        /// <summary>
        /// Listado paginado de la entidad
        /// </summary>
        public List<TEntity> Items { get; init; }

        /// <summary>
        /// Total de items en todas las paginas
        /// </summary>
        public int TotalItemCount { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public int CurentPage { get; init; }

        /// <summary>
        /// Cantida de registros maximos qu epueden mostrase por pagina, la ultima pagina podría tener menos.
        /// </summary>
        public int ItemsPerPage { get; init; }

        /// <summary>
        /// Cantidad total de paginas necesrias para mostra todos los resultados
        /// </summary>
        public int TotalPageCount { get; init; }


    }
}

