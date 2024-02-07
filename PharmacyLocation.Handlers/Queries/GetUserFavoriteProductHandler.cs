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
    public class GetUserFavoriteProductHandler : IRequestHandler<GetUserFavoriteProduct, List<FavoriteUserProduct>>
    {
        private readonly IFavoriteUserProductRepo _favoriteUserProductRepo;
        public GetUserFavoriteProductHandler(
            IFavoriteUserProductRepo favoriteUserProductRepo) {

            _favoriteUserProductRepo = favoriteUserProductRepo;
        }
        public async Task<List<FavoriteUserProduct>> Handle(GetUserFavoriteProduct request, CancellationToken cancellationToken)
        {
            return await _favoriteUserProductRepo.GetFavoritesUserProductsAsync(request.UserId);
        }
    }
}
