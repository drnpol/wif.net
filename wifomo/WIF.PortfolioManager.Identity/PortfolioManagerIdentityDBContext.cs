using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WIF.PortfolioManager.Identity.Models;
using WIF.PortfolioManager.Identity.Configurations;
using System.Data;

namespace WIF.PortfolioManager.Identity
{
    public class PortfolioManagerIdentityDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public PortfolioManagerIdentityDBContext(DbContextOptions<PortfolioManagerIdentityDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
