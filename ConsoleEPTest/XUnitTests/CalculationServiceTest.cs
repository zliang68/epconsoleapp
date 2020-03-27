using CsvFileLib.Models;
using CsvFileLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests
{
    /// <summary>
    /// CalculationService Unit Tests
    /// </summary>
    public class CalculationServiceTest
    {
        private readonly CalculationService _calculationService;

        public CalculationServiceTest()
        {
            _calculationService = new CalculationService();
        }

        [Fact]
        public void GivenListOfValue_WhenProcessed_ThenMedianValueReturned()
        {
            // Arrange
            var testData = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };

            // Act
            var medianValue = _calculationService.GetMedianValue(testData);

            // Assert
            Assert.True(medianValue == 3.0);
        }

        [Fact]
        public void GivenCsvData_WhenFiltered_ThenFiltedDataReturned()
        {
            // Arrange
            var records = new List<CsvModel>();
            for (int i = 1; i <= 5; i++)
            {
                records.Add(new CsvModel
                {
                    DataDate = DateTime.Now.AddDays(-i),
                    DataValue = i * 10.0
                });
            }
            var percentValue = 0.2;
            var values = records.Select(x => x.DataValue).ToList();

            // Act
            var medianValue = _calculationService.GetMedianValue(values);

            // Assert
            Assert.True(medianValue == 30);
            
            // Act
            var filterRecords = _calculationService.GetExceedingRecords(records, medianValue, percentValue);

            // Assert
            Assert.True(filterRecords.Any());
            Assert.True(filterRecords.Count == 4);
            Assert.NotNull(filterRecords.SingleOrDefault(x => x.DataValue == 10.0));
            Assert.NotNull(filterRecords.SingleOrDefault(x => x.DataValue == 20.0));
            Assert.NotNull(filterRecords.SingleOrDefault(x => x.DataValue == 40.0));
            Assert.NotNull(filterRecords.SingleOrDefault(x => x.DataValue == 50.0));
        }
    }
}
