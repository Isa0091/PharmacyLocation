using Isa0091.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Commands
{
    public class DeleteFavoriteUserProduct :  CommandBase
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string IdUser { get; set; }
    }
}
