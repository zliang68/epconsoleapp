using CsvFileLib.Mappers;
using CsvFileLib.Services;
using CsvHelper.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests
{
    /// <summary>
    /// CsvParserService Unit Tests
    /// 
    /// </summary>
    public class CsvParserServiceTest
    {
        private readonly ICsvParserService _csvParserService;
        private readonly Mock<IFileStreamReader> _fileStreamReader;
        public CsvParserServiceTest()
        {
            _fileStreamReader = new Mock<IFileStreamReader>();
            _csvParserService = new CsvParserService(_fileStreamReader.Object);
        }

        private StringBuilder GetCsvContentBuilder()
        {
            var testCsv = new StringBuilder();

            testCsv.AppendLine("21/08/2015 00:45:00, 2.100000");
            testCsv.AppendLine("22/08/2015 00:45:00, 2.200000");
            testCsv.AppendLine("23/08/2015 00:45:00, 2.300000");
            testCsv.AppendLine("24/08/2015 00:45:00, 2.400000");
            testCsv.AppendLine("25/08/2015 00:45:00, 2.500000");
            testCsv.AppendLine("26/08/2015 00:45:00, 2.600000");
            testCsv.AppendLine("27/08/2015 00:45:00, 2.700000");
            testCsv.AppendLine("28/08/2015 00:45:00, 2.800000");
            testCsv.AppendLine("29/08/2015 00:45:00, 2.900000");
            testCsv.AppendLine("30/08/2015 00:45:00, 3.000000");

            return testCsv;
        }

        [Fact]
        public void GivenLpCsvContent_WhenImported_ThenDataReturned()
        {
            // Arrange 
            var csvContentBuilder = GetCsvContentBuilder();            
            var lpCsvBuilder = new StringBuilder();
            lpCsvBuilder.AppendLine("Date/Time,Data Value");
            lpCsvBuilder.Append(csvContentBuilder);


            var anyPath = "anyPath";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(lpCsvBuilder.ToString()));
            _fileStreamReader.Setup(sr => sr.GetStreamReader(anyPath)).Returns(new StreamReader(ms));

            // Act
            var results = _csvParserService.ReadCsvFileToCsvModel(anyPath, new LpMap());

            // Assert
            Assert.True(results.Any());
        }

        [Fact]
        public void GivenTouCsvContent_WhenImported_ThenDataReturned()
        {
            // Arrange
            var csvContentBuilder = GetCsvContentBuilder();
            var touCsvBuilder = new StringBuilder();
            touCsvBuilder.AppendLine("Date/Time,Energy");
            touCsvBuilder.Append(csvContentBuilder);

            var anyPath = "anyPath";
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(touCsvBuilder.ToString()));
            _fileStreamReader.Setup(sr => sr.GetStreamReader(anyPath)).Returns(new StreamReader(ms));

            // Act
            var results = _csvParserService.ReadCsvFileToCsvModel(anyPath, new TouMap());

            // Assert
            Assert.True(results.Any());
        }
    }
}
