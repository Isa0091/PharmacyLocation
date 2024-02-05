using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Outputs
{
    /// <summary>
    /// 
    /// </summary>
    public class PharmacyOutput
    {
        /// <summary>
        /// Identificador de la farmacia
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Descripcion de la farmacia
        /// </summary>
        public DescriptionVo Description { get; set; }

        /// <summary>
        /// Hubicacion de la farmacia
        /// </summary>
        public LocationVo Location { get; set; }
    }
}
