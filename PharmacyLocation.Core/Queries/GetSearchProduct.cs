using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Queries
{
    public class GetSearchProduct : QueryBase<List<Product>>
    {
        /// <summary>
        /// Producto que contenga dicho nombre
        /// </summary>
        public string NameContains { get; set; }

        /// <summary>
        /// Identificadores de los productos
        /// </summary>
        public List<string> IdsProducts { get; set; }
    }
}
