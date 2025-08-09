using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Persistence;
using WIF.PortfolioManager.Persistence.Repositories;
using WIF.PortfolioManager.Application.Services;
using WIF.Common.Identity.Models;
using WIF.PortfolioManager.Application;
using WIF.Common.Identity;

namespace WIF.PortfolioManager.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Entity Framework services to the container.
            builder.Services.AddDbContext<ApplicationIdentityDBContext>(options =>
                options
                    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .ConfigureWarnings(b => b.Log(CoreEventId.ManyServiceProvidersCreatedWarning))
            );

            builder.Services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDBContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });

            builder.Services.AddAuthorization();

            //builder.Services.AddScoped<UnitOfWork>();
            //builder.Services.AddScoped<BBWalletImportService>();

            builder.Services.AddSingleton<AppSettings>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
