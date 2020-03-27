using CsvFileLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace CsvFileLib.Services
{
    public class CalculationService : ICalculationService
    {
        /// <summary>
        /// Get median value from list of values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public double GetMedianValue(List<double> values)
        {
            return Queryable.Average(values.AsQueryable());
        }

        /// <summary>
        /// Get records that exceeding parcentValue above or lower baseValue
        /// </summary>
        /// <param name="records"></param>
        /// <param name="baseValue"></param>
        /// <param name="percentValue"></param>
        public List<CsvModel> GetExceedingRecords(List<CsvModel> records, double baseValue, double percentValue)
        {
            var highValue = baseValue * (1.0 + percentValue);
            var lowValue = baseValue * (1.0 - percentValue);

            var results = records.Where(x => x.DataValue > highValue || x.DataValue < lowValue).ToList();
            return results;
        }

    }
}
