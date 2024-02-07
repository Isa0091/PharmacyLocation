using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    /// <summary>
    /// Datos favoritos
    /// </summary>
    public class FavoriteUserProduct : RootEntity
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Para la llave foranea del producto
        /// </summary>
        private Product Product { get; set; }
    }
}
