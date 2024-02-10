using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    public  class PharmacyLocationProductOutput : PharmacyLocationOutput
    {

        /// <summary>
        /// Indica la cantidad de productos
        /// </summary>
        public int Stock { get; set; }
    }
}
