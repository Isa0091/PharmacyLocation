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
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        private readonly PharmacyLocationContext _db;
        public CategoryRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetCategoriesAsync(List<string> categoriesIds)
        {
            return await _db.Categories.Where(z=> categoriesIds.Contains(z.Id)).ToListAsync();
        }
    }
}
