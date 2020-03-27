using CsvFileLib.Models;
using CsvHelper.Configuration;
using System.Collections.Generic;

namespace CsvFileLib.Services
{
    public interface ICsvParserService
    {
        /// <summary>
        /// Interace of ReadCsvFileToCsvModel method
        /// </summary>
        /// <param name="path"></param>
        /// <param name="classMap"></param>
        /// <returns></returns>
        List<CsvModel> ReadCsvFileToCsvModel(string path, ClassMap classMap);
    }
}
