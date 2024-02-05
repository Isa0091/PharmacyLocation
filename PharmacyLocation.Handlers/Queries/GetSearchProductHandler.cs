using MediatR;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Queries
{
    public class GetSearchProductHandler : IRequestHandler<GetSearchProduct, List<Product>>
    {
        public Task<List<Product>> Handle(GetSearchProduct request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
