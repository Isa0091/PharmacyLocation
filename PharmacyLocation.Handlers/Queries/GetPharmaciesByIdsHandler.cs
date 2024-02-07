﻿using MediatR;
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
    class GetPharmaciesByIdsHandler : IRequestHandler<GetPharmaciesByIds, List<Pharmacy>>
    {
        private readonly IPharmacyRepo _pharmacyRepo;
        public GetPharmaciesByIdsHandler(
            IPharmacyRepo pharmacyRep)
        {
            _pharmacyRepo = pharmacyRep;
        }

        public async Task<List<Pharmacy>> Handle(GetPharmaciesByIds request, CancellationToken cancellationToken)
        {
            return await _pharmacyRepo.GetPharmacyAsync(request.PharmaciesIds);
        }
    }
}
