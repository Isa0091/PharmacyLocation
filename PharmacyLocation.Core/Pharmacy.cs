using Isa0091.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    /// <summary>
    /// Farmacia
    /// </summary>
    public class Pharmacy : RootEntity
    {
        public Pharmacy() { 
          PharmacySchedules = new List<PharmacySchedule>();
        }
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

        /// <summary>
        /// Imagen que hace referencia la producto
        /// </summary>
        public string? UrlImage { get; set; }

        /// <summary>
        /// Indica que la farmacia es 24/7
        /// </summary>
        public bool IsOpenAllHours { get; set; }
        /// <summary>
        /// Indica los horarios de la farmacia
        /// </summary>
        public List<PharmacySchedule> PharmacySchedules { get; set; }
    }
}
