using MediatR;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyLocation.Core.Data;
using PharmacyLocation.Exceptions;

namespace PharmacyLocation.Handlers.Queries
{
    class GetProductsByIdsHandler : IRequestHandler<GetProductsByIds, List<Product>>
    {
        private readonly IProductRepo _productRepo;
        public GetProductsByIdsHandler(
            IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<Product>> Handle(GetProductsByIds request, CancellationToken cancellationToken)
        {
            return await _productRepo.GetByIdsAsync(request.ProductsIds);
        }
    }
}
