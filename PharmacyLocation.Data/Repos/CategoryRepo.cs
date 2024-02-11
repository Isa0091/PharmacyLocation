using PharmacyLocation.Core.Data;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacyLocation.Outputs;
using System.Linq.Expressions;

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

        public async Task<PaginatedListOutput<Category>> GetPaginatedCategoriesAsync(string? nameContains, int page, int itemsPerPage)
        {

            Expression<Func<Category, bool>> where = x => (string.IsNullOrEmpty(nameContains) || x.Description.Name.Contains(nameContains));

            int skip = itemsPerPage * (page - 1);

            var items = await _db.Categories.OrderBy(z=> z.Description.Name)
                                      .Where(where)
                                      .Skip(skip)
                                      .Take(itemsPerPage)
                                      .ToListAsync();

            int totalItems = await _db.Categories.CountAsync(where);

            return new PaginatedListOutput<Category>(items, totalItems, page, itemsPerPage);
        }
    }
}
