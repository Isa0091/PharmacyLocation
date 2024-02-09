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
    class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly IProductRepo _productRepo;
        public GetProductByIdHandler(
            IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepo.GetByIdAsync(request.ProductId);  
            
            if (product == null)
                throw NotFoundException.CreateException(NotFoundExceptionType.Product, nameof(request.ProductId), this.GetType());

            return product;
        }
    }
}
