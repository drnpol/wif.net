using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Persistence.Repositories;

namespace WIF.PortfolioManager.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationPersistenceDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<UnitOfWork>();
            services.AddScoped<BBWalletImportRepository>();

            return services;
        }
    }
}
