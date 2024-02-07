using MediatR;
using Microsoft.Extensions.Options;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Data;
using PharmacyLocation.Core.Queries;
using PharmacyLocation.Outputs;
using PharmacyLocation.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Queries
{
    public class GetSearchProductHandler : IRequestHandler<GetSearchProduct, PaginatedListOutput<Product>>
    {
        private readonly IProductRepo _productRepo;
        private readonly IOptionsSnapshot<DefaultPaginationSettings> _paginationSettings;
        public GetSearchProductHandler(
            IProductRepo productRepo,
            IOptionsSnapshot<DefaultPaginationSettings> paginationSettings) {

            _productRepo = productRepo;
            _paginationSettings = paginationSettings;
        }
        public async Task<PaginatedListOutput<Product>> Handle(GetSearchProduct request, CancellationToken cancellationToken)
        {
            PaginatedListOutput<Product> paginatedListOutput =
               await _productRepo.GetPaginatedProductsAsync(request.NameContains,
               request.Page ?? 1, request.ItemsPerPage ?? _paginationSettings.Value.ItemsPerPage);

            return paginatedListOutput;
        }
    }
}
