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
    class GetSearchPharmacyProductHandler : IRequestHandler<GetSearchPharmacyProduct, List<PharmacyProduct>>
    {
        public Task<List<PharmacyProduct>> Handle(GetSearchPharmacyProduct request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
