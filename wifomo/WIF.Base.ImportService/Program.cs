using System.Globalization;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Collections.Generic;
using WIF.Base.ImportService.Models;
using Microsoft.Extensions.Logging;
using WIF.Core.Models;
using WIF.Base.ImportService.Mapper;
using WIF.Base.ImportService.Extensions;
using Microsoft.EntityFrameworkCore;
using WIF.Core.Data;
using Microsoft.IdentityModel.Tokens;

namespace WIF.Base.ImportService
{
    
    internal class Program
    {
        
        static void Main(string[] args)

        {
            // Create Logger
            using var loggerFactory = LoggerFactory.Create(loggerBuilder =>
            {
                // Add console logging
                loggerBuilder.AddConsole();
                // Optionally, configure the logging level
                loggerBuilder.SetMinimumLevel(LogLevel.Information);
            });

            ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Program starting...");

            // Check the Environment
            String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            String appSettingsFileName= $"appsettings.{env}.json";

            logger.LogInformation($"Loading appsettings.{env}.json");

            // Read appsettings.json
            ConfigurationBuilder configBuilder= new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configBuilder.AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true);

            IConfiguration config = configBuilder.Build();

            // Create DB Context
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            using var dbContext = new ApplicationDbContext(optionsBuilder.Options);


            // Load File Configs to be processed
            List<FileConfig> fileConfigs = config.GetSection("FileConfigs").Get<List<FileConfig>>();
            foreach (var fileConfig in fileConfigs)
            {
                logger.LogInformation(fileConfig.ToString());
                // Load CSV from file configs
                StreamReader streamReader = new StreamReader(fileConfig.Path);
                CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

                csvReader.Context.RegisterClassMap<BBWalletImportMapper>();

                // Map CSV Lines / Rows into EF Core Models
                var rows = csvReader.GetRecords<BBWalletImport>().ToList();

                logger.LogInformation($"Processing rows: {rows.Count}");
                int success = 0;
                int failure = 0;
                int skipped = 0;
                foreach(var row in rows)
                {
                    // Insert records into Database
                    try
                    {

                        // Check if record already exists
                        var exists = dbContext.BBWalletImports
                            .Any(
                                dbRow => dbRow.Account == row.Account &&
                                         dbRow.Category == row.Category &&
                                         dbRow.Currency == row.Currency &&
                                         dbRow.Amount == row.Amount &&
                                         dbRow.Type == row.Type &&
                                         dbRow.PaymentType == row.PaymentType &&
                                         dbRow.Note == row.Note &&
                                         dbRow.Date == row.Date &&
                                         dbRow.Transfer == row.Transfer &&
                                         dbRow.Payee == row.Payee &&
                                         dbRow.Labels == row.Labels &&
                                         dbRow.EnvelopeId == row.EnvelopeId
                            );

                        if (exists)
                        {
                            skipped++;
                            logger.LogWarning($@"Row: Account={row.Account},Note={row.Note}, Date={row.Date.ToString()} already exists in the table.");
                            continue;
                        }

                        var result = dbContext.BBWalletImports.Add(row);
                        dbContext.SaveChanges();

                        success++;
                        //logger.LogInformation($"Successfully inserted row: {row} to table.");

                    }
                    catch(Exception err)
                    {
                        failure++;
                        logger.LogInformation($"Error inserting row to table: {err.Message}");
                    }
                }
                logger.LogInformation($"Success: {success}, Failure: {failure}, Skipped: {skipped}");
            }
        }
    }
}
