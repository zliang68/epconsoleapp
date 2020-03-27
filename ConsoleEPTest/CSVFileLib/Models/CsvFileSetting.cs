namespace CsvFileLib.Models
{
    /// <summary>
    /// Model for CsvFile app setting 
    /// </summary>
    public class CsvFileSetting
    {
        public string FilePath { get; set; }
        public string LpFilePrefix { get; set; }
        public string TouFilePrefix { get; set; }
        public int DetectPercentage { get; set; }
    }
}
