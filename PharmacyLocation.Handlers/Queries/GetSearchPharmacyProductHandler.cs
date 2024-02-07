using MediatR;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Data;
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
        private readonly IPharmacyProductRepo _pharmacyProductRepo;
        public GetSearchPharmacyProductHandler(IPharmacyProductRepo pharmacyProductRepo)
        {
            _pharmacyProductRepo = pharmacyProductRepo;
        }
        public async Task<List<PharmacyProduct>> Handle(GetSearchPharmacyProduct request, CancellationToken cancellationToken)
        {
            return await _pharmacyProductRepo.GetPharmacyProductsByIdAsync(request.ProductId);
        }
    }
}
