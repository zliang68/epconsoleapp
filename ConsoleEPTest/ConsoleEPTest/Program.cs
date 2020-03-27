using CsvFileLib.Models;
using CsvFileLib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace ConsoleEPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add configuration 
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("AppSettings.json");

            // Retrieve CSV file Setting
            var config = builder.Build();
            var csvFileSetting = config.GetSection("CsvFile").Get<CsvFileSetting>();

            // Setup DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppHost, AppHost>()
                .AddSingleton<ICsvParserService, CsvParserService>()
                .AddSingleton<ICalculationService, CalculationService>()
                .AddSingleton<IFileStreamReader, FileStreamReader>()
                .BuildServiceProvider();

            // Run host
            serviceProvider.GetService<IAppHost>().Run(csvFileSetting);
        }
    }

}
