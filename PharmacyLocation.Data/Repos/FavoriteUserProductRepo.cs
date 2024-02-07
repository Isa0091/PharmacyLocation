using Microsoft.EntityFrameworkCore;
using PharmacyLocation.Core;
using PharmacyLocation.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Repos
{
    public class FavoriteUserProductRepo : BaseRepo<FavoriteUserProduct>, IFavoriteUserProductRepo
    {
        private readonly PharmacyLocationContext _db;
        public FavoriteUserProductRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }


        public  async Task<FavoriteUserProduct?> GetFavoriteUserProductByIdAsync(string userId,string productId)
        {
            return await _db.FavoriteUserProducts.SingleOrDefaultAsync(z=> z.ProductId == productId && z.UserId == userId);
        }

        public async Task<List<FavoriteUserProduct>> GetFavoritesUserProductsAsync(string userId)
        {
            return await _db.FavoriteUserProducts.Where(z =>  z.UserId == userId).ToListAsync();
        }
    }
}
