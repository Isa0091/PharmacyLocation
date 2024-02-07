using MediatR;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Commands;
using PharmacyLocation.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Handlers.Commands
{
    class DeleteFavoriteUserProductHandler : IRequestHandler<DeleteFavoriteUserProduct>
    {
        private readonly IFavoriteUserProductRepo _favoriteUserProductRepo;

        public DeleteFavoriteUserProductHandler(IFavoriteUserProductRepo favoriteUserProductRepo)
        {
            _favoriteUserProductRepo = favoriteUserProductRepo;
        }

        public async Task<Unit> Handle(DeleteFavoriteUserProduct request, CancellationToken cancellationToken)
        {
            FavoriteUserProduct? favoriteUserProduct = await _favoriteUserProductRepo.GetFavoriteUserProductByIdAsync(request.IdUser,request.ProductId);

            if(favoriteUserProduct != null)
            {
                await _favoriteUserProductRepo.RemoveAsync(favoriteUserProduct);   
                await _favoriteUserProductRepo.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
