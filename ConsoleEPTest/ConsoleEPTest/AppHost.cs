using CsvFileLib.Mappers;
using CsvFileLib.Models;
using CsvFileLib.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleEPTest
{
    public class AppHost : IAppHost
    {
        private readonly ICsvParserService _csvParserService;
        private readonly ICalculationService _calculationService;

        /// <summary>
        /// Initiate services using DI
        /// </summary>
        public AppHost(ICsvParserService csvParserService, ICalculationService calculationService)
        {
            _csvParserService = csvParserService;
            _calculationService = calculationService;
        }

        /// <summary>
        /// Startup here
        /// </summary>
        /// <param name="csvFileSetting"></param>
        public void Run(CsvFileSetting csvFileSetting)
        {            
            var files = Directory.GetFiles(csvFileSetting.FilePath, "*.csv", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                // Check file type
                var isLpFile = fileName.StartsWith(csvFileSetting.LpFilePrefix);
                var isTouFile = fileName.StartsWith(csvFileSetting.TouFilePrefix);

                var records = isLpFile
                    ? _csvParserService.ReadCsvFileToCsvModel(file, new LpMap())
                    : isTouFile
                        ? _csvParserService.ReadCsvFileToCsvModel(file, new TouMap())
                        : new List<CsvModel>();

                // Skip unknown CSV file
                if (!records.Any())
                {
                    Console.WriteLine($"*** Unknown file type: {fileName}");
                    continue;
                }

                // Filter records 
                var medianValue = _calculationService.GetMedianValue(records.Select(x => x.DataValue).ToList());

                var percentValue = csvFileSetting.DetectPercentage / 100.0;

                var exceedingRecords = _calculationService.GetExceedingRecords(records, medianValue, percentValue);

                // Display filtered records
                OutputRecords(fileName, exceedingRecords, medianValue);
            }
        }

        #region Helpers
        /// <summary>
        /// Output records with file name and median value
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="detectedRecords"></param>
        /// <param name="medianValue"></param>
        private void OutputRecords(string fileName, List<CsvModel> detectedRecords, double medianValue)
        {
            // Output records using tab separator 
            foreach (var item in detectedRecords)
            {
                Console.WriteLine($"{fileName}\t{item.DataDate}\t{item.DataValue}\t{medianValue}");
            }
        }

        #endregion

    }
}
