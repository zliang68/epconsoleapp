using CsvFileLib.Models;
using CsvHelper.Configuration;

namespace CsvFileLib.Mappers
{
    /// <summary>
    /// CSVHelper mapping for 'TOU' type CSV files
    /// </summary>

    public sealed class TouMap : ClassMap<CsvModel>
    {
        public TouMap()
        {
            Map(m => m.DataDate).Name(Constants.CsvHeaders.DataDate);
            Map(m => m.DataValue).Name(Constants.CsvHeaders.Energy);
        }
    }
}
