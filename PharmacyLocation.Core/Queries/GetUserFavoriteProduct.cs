using Isa0091.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core.Queries
{
    public class GetUserFavoriteProduct : QueryBase<List<FavoriteUserProduct>>
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public string IdUser { get; set; }
    }
}
