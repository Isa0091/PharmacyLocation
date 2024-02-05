using MediatR;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Commands
{
    class CreateFavoriteUserProductHandler : IRequestHandler<CreateFavoriteUserProduct, FavoriteUserProduct>
    {
        public Task<FavoriteUserProduct> Handle(CreateFavoriteUserProduct request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
