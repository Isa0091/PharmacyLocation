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
    public class GetSearchCategorieshandler : IRequestHandler<GetSearchCategories, PaginatedListOutput<Category>>
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IOptionsSnapshot<DefaultPaginationSettings> _paginationSettings;
        public GetSearchCategorieshandler(
            ICategoryRepo categoryRepo,
            IOptionsSnapshot<DefaultPaginationSettings> paginationSettings) {

            _categoryRepo = categoryRepo;
            _paginationSettings = paginationSettings;
        }

        public async Task<PaginatedListOutput<Category>> Handle(GetSearchCategories request, CancellationToken cancellationToken)
        {
            PaginatedListOutput<Category> paginatedListOutput =
               await _categoryRepo.GetPaginatedCategoriesAsync(request.NameContains,
               request.Page ?? 1, request.ItemsPerPage ?? _paginationSettings.Value.ItemsPerPage);

            return paginatedListOutput;
        }
    }
}
