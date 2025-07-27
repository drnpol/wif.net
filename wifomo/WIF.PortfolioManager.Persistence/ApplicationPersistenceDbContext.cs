using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Persistence.Configurations.Entities;

namespace WIF.PortfolioManager.Persistence
{
    public partial class ApplicationPersistenceDbContext : DbContext
    {
        public ApplicationPersistenceDbContext(DbContextOptions<ApplicationPersistenceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new BBWalletImportConfiguration());
        }

        public virtual DbSet<BBWalletImport> BBWalletImports { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }

        public virtual async Task<int> SaveChangesAsync(Guid userUid)
        {
            foreach (var entry in base.ChangeTracker.Entries<ModelBase>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                entry.Entity.UpdatedByUserUid = userUid;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedByUserUid = userUid;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
    }
}
