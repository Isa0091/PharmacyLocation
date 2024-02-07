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
    class CreateFavoriteUserProductHandler : IRequestHandler<CreateFavoriteUserProduct, FavoriteUserProduct>
    {
        private readonly IFavoriteUserProductRepo _favoriteUserProductRepo;

        public CreateFavoriteUserProductHandler(IFavoriteUserProductRepo favoriteUserProductRepo)
        {
            _favoriteUserProductRepo = favoriteUserProductRepo;
        }

        public async Task<FavoriteUserProduct> Handle(CreateFavoriteUserProduct request, CancellationToken cancellationToken)
        {
            FavoriteUserProduct? favoriteUserProduct = await _favoriteUserProductRepo.GetFavoriteUserProductByIdAsync(request.IdUser,request.ProductId);

            if(favoriteUserProduct == null)
            {

                favoriteUserProduct = new FavoriteUserProduct()
                {
                     ProductId = request.ProductId,
                     UserId = request.IdUser,
                
                };

                await _favoriteUserProductRepo.AddAsync(favoriteUserProduct);   
                await _favoriteUserProductRepo.SaveChangesAsync();
            }

            return favoriteUserProduct;
        }
    }
}
