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
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();


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

                logger.LogInformation($"Row Count: {rows.Count}");
               
                rows.ForEach(row =>
                {
                    // Insert records into Database
                    logger.LogInformation(row.ToCustomString());
                });

                

                

                
            }






        }
    }
}
