using CsvFileLib.Models;
using System.Collections.Generic;

namespace CsvFileLib.Services
{
    public interface ICalculationService
    {
        /// <summary>
        /// Interface of GetMediaValue method
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        double GetMedianValue(List<double> list);

        /// <summary>
        /// Interface of GetExceedingRecords method
        /// </summary>
        /// <param name="records"></param>
        /// <param name="baseValue"></param>
        /// <param name="percentValue"></param>
        /// <returns></returns>
        List<CsvModel> GetExceedingRecords(List<CsvModel> records, double baseValue, double percentValue);
    }
}