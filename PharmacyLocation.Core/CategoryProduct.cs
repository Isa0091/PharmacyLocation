using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    public class CategoryProduct :Entity
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Identificador de la farmacia
        /// </summary>
        private string ProductId { get; set; }

        /// <summary>
        /// para la llave foranea
        /// </summary>
        private Product Product { get; set; }
    }
}
