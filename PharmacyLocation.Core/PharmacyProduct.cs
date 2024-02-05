using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    public class PharmacyProduct : RootEntity
    {
        
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string IdProduct { get; set; }

        /// <summary>
        /// Identificador de la farmacia
        /// </summary>
        public string IdPharmacy { get; set; }

        /// <summary>
        /// para la llave foranea
        /// </summary>
        private Product Product { get; set; }

        /// <summary>
        /// para la llave foranea
        /// </summary>
        private Pharmacy Pharmacy { get; set; }
    }
}
