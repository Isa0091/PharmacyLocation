using PharmacyLocation.Core.Data;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyLocation.Outputs;
using Azure;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PharmacyLocation.Data.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly PharmacyLocationContext _db;
        public ProductRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }

        public async Task<PaginatedListOutput<Product>> GetPaginatedProductsAsync(string nameContains, int page, int itemsPerPage)
        {
            Expression<Func<Product, bool>> where = x => (string.IsNullOrEmpty(nameContains) || x.Description.Name.Contains(nameContains));

            int skip = itemsPerPage * (page - 1);

            var items = await _db.Products
                                      .Where(where)
                                      .Skip(skip)
                                      .Take(itemsPerPage)
                                      .ToListAsync();

            int totalItems = await _db.Products.CountAsync(where);

            return new PaginatedListOutput<Product>(items, totalItems, page, itemsPerPage);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _db.Products.SingleAsync(x => x.Id == id);
        }
    }
}
