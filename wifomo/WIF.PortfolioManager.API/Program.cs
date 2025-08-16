
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WIF.Common.Identity.Models;
using WIF.Common.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WIF.PortfolioManager.API.Middlewares;

namespace WIF.PortfolioManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ExceptionMiddleware>();
            builder.Services.AddScoped<AuthenticationMiddleware>();

            // Add Entity Framework services to the container.
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllers();

            //if (!builder.Environment.IsDevelopment()) // just added for fun HAHA
            //{
            //    builder.Services.Configure<ApiBehaviorOptions>(options =>
            //    {
            //        options.SuppressConsumesConstraintForFormFileParameters = true;
            //        options.SuppressInferBindingSourcesForParameters = true;
            //        options.SuppressModelStateInvalidFilter = true; // automatic error messages when request body is invalid
            //        options.SuppressMapClientErrors = true;
            //        options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
            //            "https://httpstatuses.com/404";
            //    });
            //}
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("all", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // custom middlewares
            app.UseMiddleware<ExceptionMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
