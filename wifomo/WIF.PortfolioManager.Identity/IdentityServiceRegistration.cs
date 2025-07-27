using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WIF.PortfolioManager.Identity.Models;

namespace WIF.PortfolioManager.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<PortfolioManagerIdentityDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString"),
                b => b.MigrationsAssembly(typeof(PortfolioManagerIdentityDBContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<PortfolioManagerIdentityDBContext>().AddDefaultTokenProviders();

            //services.AddTransient<IAuthService, AuthService>();
            //services.AddTransient<IUserService, UserService>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JwtSettings:Issuer"],
            //            ValidAudience = configuration["JwtSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //        };
            //    });

            return services;
        }
    }
}
