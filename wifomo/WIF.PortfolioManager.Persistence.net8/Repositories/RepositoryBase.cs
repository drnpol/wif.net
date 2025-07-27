using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using WIF.PortfolioManager.Persistence;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public abstract class RepositoryBase<K>
    {
        protected readonly ApplicationDbContext db;
        public RepositoryBase(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
    }

    public abstract class RepositoryBase<K, TEntity> : RepositoryBase<K> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public ApplicationDbContext DbContext { get; }

        public RepositoryBase(ApplicationDbContext dbContext) : base(dbContext)
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

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.RemoveRange(entities);
        }
    }
}
