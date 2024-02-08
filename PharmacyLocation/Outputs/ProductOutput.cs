using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    public class ProductOutput
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public DescriptionVo Description { get; set; }

        /// <summary>
        /// Imagen que hace referencia la producto
        /// </summary>
        public string? UrlImage { get; set; }
    }
}
