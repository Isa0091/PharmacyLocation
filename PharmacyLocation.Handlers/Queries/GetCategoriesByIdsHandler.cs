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
    class GetCategoriesByIdsHandler : IRequestHandler<GetCategoriesByIds, List<Category>>
    {
        private readonly ICategoryRepo _categoryRepo;
        public GetCategoriesByIdsHandler(
            ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<Category>> Handle(GetCategoriesByIds request, CancellationToken cancellationToken)
        {
            return await _categoryRepo.GetCategoriesAsync(request.CategoriesIds);
        }
    }
}
