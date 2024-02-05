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

    }
}
