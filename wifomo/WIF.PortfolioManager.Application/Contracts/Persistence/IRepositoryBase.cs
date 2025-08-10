using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Application.Contracts.Persistence
{
    public interface IRepositoryBase<K, TEntity>
    {
        public Task<TEntity> GetOne(K key);
        public Task<bool> Any(K key);
        public TEntity Insert(TEntity entity);
        public TEntity Create(TEntity entity);
        public TEntity Update(TEntity entity);
        public bool Delete(TEntity entity);
    }
}
