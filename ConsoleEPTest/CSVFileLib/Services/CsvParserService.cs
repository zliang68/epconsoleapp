using CsvFileLib.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CsvFileLib.Services
{
    public class CsvParserService : ICsvParserService
    {
        private readonly IFileStreamReader _reader;

        public CsvParserService(IFileStreamReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Read a CSV file and return imported data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="classMap"></param>
        /// <returns></returns>
        public List<CsvModel> ReadCsvFileToCsvModel(string path, ClassMap classMap)
        {
            try
            {
                using (var reader = _reader.GetStreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-AU")))
                {
                    csv.Configuration.RegisterClassMap(classMap);
                    var records = csv.GetRecords<CsvModel>().ToList();
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
