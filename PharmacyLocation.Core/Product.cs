using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    public class Product : RootEntity
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public DescriptionVo Description { get; set; }

    }
}
