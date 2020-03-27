using CsvFileLib.Models;

namespace ConsoleEPTest
{
    public interface IAppHost
    {
        /// <summary>
        /// Interface of Run method
        /// </summary>
        /// <param name="csvFileSetting"></param>
        void Run(CsvFileSetting csvFileSetting);
    }
}