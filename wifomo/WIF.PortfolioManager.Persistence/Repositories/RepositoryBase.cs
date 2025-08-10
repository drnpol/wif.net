using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using WIF.PortfolioManager.Persistence;
using Microsoft.Data.SqlClient;
using System.Data;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public abstract class RepositoryBase<K>
    {
        protected readonly ApplicationPersistenceDbContext db;
        public RepositoryBase(ApplicationPersistenceDbContext dbContext)
        {
            this.db = dbContext;
        }
    }

    public abstract class RepositoryBase<K, TEntity> : RepositoryBase<K> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public ApplicationPersistenceDbContext DbContext { get; }

        public RepositoryBase(ApplicationPersistenceDbContext dbContext) : base(dbContext)
        {
            this.dbSet = dbContext.Set<TEntity>();
        }

        public ValueTask<EntityEntry<TEntity>> Insert(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public Task<int> Count()
        {
            return this.dbSet.CountAsync();
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return this.dbSet.Update(entity);
        }
        public EntityEntry<TEntity> Remove(TEntity entity)
        {
            return this.dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.RemoveRange(entities);
        }
    }
}
