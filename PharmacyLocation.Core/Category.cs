using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    public class Category : RootEntity
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
