using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using WIF.Core.Data;

namespace WIF.Core.Repositories
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

        private readonly ApplicationDbContext dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task SaveChanges()
            => this.dbContext.SaveChangesAsync();

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return this.dbContext.Database.BeginTransactionAsync();
        }
    }
}
