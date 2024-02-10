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
    public class PharmacyRepo : BaseRepo<Pharmacy>, IPharmacyRepo
    {
        private readonly PharmacyLocationContext _db;
        public PharmacyRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Pharmacy>> GetPharmacyAsync(List<string> pharmaciesIds)
        {
            return await _db.Pharmacies.Where(z=> pharmaciesIds.Contains(z.Id)).ToListAsync();
        }

        public async Task<List<Pharmacy>> GetAllAsync()
        {
            return await _db.Pharmacies.ToListAsync();
        }
    }
}
