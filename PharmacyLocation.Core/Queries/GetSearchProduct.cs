using Isa0091.Domain.Core.Queries;
using PharmacyLocation.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Queries
{
    public class GetSearchProduct : QueryBase<PaginatedListOutput<Product>>
    {
        /// <summary>
        /// Producto que contenga dicho nombre
        /// </summary>
        public string? NameContains { get; set; }

        /// <summary>
        /// La pagina que se quiere navegar
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// La cantidad por pagina que se desea, por defecto es 100
        /// </summary>
        public int? ItemsPerPage { get; set; }
    }
}
