using Isa0091.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;
using PharmacyLocation.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Data.Repos
{
    public abstract class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : RootEntity
    {
        protected readonly PharmacyLocationContext Db;

        protected BaseRepo(PharmacyLocationContext db)
        {
            Db = db;
        }

        public async Task AddAsync(TEntity entidad)
        {
            await Db.Set<TEntity>().AddAsync(entidad);
        }

        public Task UpdateAsync(TEntity entidad)
        {
            Db.Set<TEntity>().Update(entidad);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Db.Set<TEntity>().ToListAsync();
        }
    }
}