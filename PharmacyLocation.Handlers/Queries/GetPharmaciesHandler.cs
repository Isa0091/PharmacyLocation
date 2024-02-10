using MediatR;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyLocation.Core.Data;

namespace PharmacyLocation.Handlers.Queries
{
    class GetPharmaciesHandler : IRequestHandler<GetPharmacies, List<Pharmacy>>
    {
        private readonly IPharmacyRepo _pharmacyRepo;
        public GetPharmaciesHandler(
            IPharmacyRepo pharmacyRep)
        {
            _pharmacyRepo = pharmacyRep;
        }

        public async Task<List<Pharmacy>> Handle(GetPharmacies request, CancellationToken cancellationToken)
        {
            return await _pharmacyRepo.GetAllAsync();
        }
    }
}
