using PharmacyLocation.Core.Data;
using PharmacyLocation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Repos
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly PharmacyLocationContext _db;
        public ProductRepo(PharmacyLocationContext db) : base(db)
        {
            _db = db;
        }

    }
}
