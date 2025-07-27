using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WIF.Common.Identity.Models;
using WIF.Common.Identity.Configurations;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace WIF.Common.Identity
{
    public class ApplicationIdentityDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationIdentityDBContext(DbContextOptions<ApplicationIdentityDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("wif_users");
            modelBuilder.Entity<ApplicationRole>().ToTable("wif_roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("wif_user_roles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("wif_user_claims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("wif_user_logins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("wif_role_claims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("wif_user_tokens");

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
