using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace WIF.Common.Identity
{
    public class DesignTimeIdentityDBContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDBContext>
    {
        public ApplicationIdentityDBContext CreateDbContext(string[] args)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            Console.WriteLine($"[EF] Current Environment = {env}");

            // Adjust path if needed (based on project structure)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"[EF] Connection string used = {connectionString}");
            optionsBuilder.UseNpgsql(connectionString)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            return new ApplicationIdentityDBContext(optionsBuilder.Options);
        }
    }
}
