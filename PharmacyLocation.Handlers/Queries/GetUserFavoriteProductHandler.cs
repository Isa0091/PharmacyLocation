using MediatR;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Queries
{
    public class GetUserFavoriteProductHandler : IRequestHandler<GetUserFavoriteProduct, List<FavoriteUserProduct>>
    {
        public Task<List<FavoriteUserProduct>> Handle(GetUserFavoriteProduct request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
