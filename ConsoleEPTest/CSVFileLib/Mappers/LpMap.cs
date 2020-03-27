using CsvFileLib.Models;
using CsvHelper.Configuration;

namespace CsvFileLib.Mappers
{
    /// <summary>
    /// CSVHelper mapping for 'LP' type CSV files
    /// </summary>
    public sealed class LpMap : ClassMap<CsvModel>
    {
        public LpMap()
        {
            Map(m => m.DataDate).Name(Constants.CsvHeaders.DataDate);
            Map(m => m.DataValue).Name(Constants.CsvHeaders.DataValue);
        }
    }
}
