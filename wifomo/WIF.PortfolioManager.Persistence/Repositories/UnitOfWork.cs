using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private RoleRepository _roleRepository;
        public RoleRepository RoleRepository
        {
            get
            {
                _roleRepository ??= new(dbContext);

                return _roleRepository;
            }
        }
        private UserRepository _userRepository;
        public  UserRepository UserRepository
        {
            get
            {
                _userRepository ??= new(dbContext);

                return _userRepository;
            }
        }
        private BBWalletImportRepository _bbWalletImportRepository;
        public BBWalletImportRepository BBWalletImportRepository
        {
            get
            {
                _bbWalletImportRepository ??= new(dbContext);

                return _bbWalletImportRepository;
            }
        }

        private readonly ApplicationPersistenceDbContext dbContext;
        public UnitOfWork(ApplicationPersistenceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task SaveChanges()
        {
            // @TODO - add accessing user here, empty user id will be the system for the time being.
            return this.dbContext.SaveChangesAsync(Guid.Empty);
        }

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return this.dbContext.Database.BeginTransactionAsync();
        }
    }
}
