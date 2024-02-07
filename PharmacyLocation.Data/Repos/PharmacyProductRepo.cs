using PharmacyLocation.Core.Data;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmacyLocation.Data.Repos
{
    public class PharmacyProductRepo : BaseRepo<PharmacyProduct>, IPharmacyProductRepo
    {
        private readonly PharmacyLocationContext _db;
        public PharmacyProductRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<PharmacyProduct>> GetPharmacyProductsByIdAsync(string productId)
        {
            return await _db.PharmacyProducts.Where(z=> z.IdProduct == productId).ToListAsync();
        }
    }
}
