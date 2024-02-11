using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    public class CategoryOutput
    {
        /// Identificador de la categoria
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descripcion de la categoria
        /// </summary>
        public DescriptionVo Description { get; set; }

        /// <summary>
        /// Imagen que hace referencia la categoria
        /// </summary>
        public string? UrlImage { get; set; }
    }
}
