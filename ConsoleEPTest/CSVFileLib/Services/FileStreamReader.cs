using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvFileLib.Services
{
    /// <summary>
    /// Make it unit testable
    /// </summary>
    public class FileStreamReader : IFileStreamReader
    {
        /// <summary>
        /// Return a new StreamReader object
        /// Easy for unit testing
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StreamReader GetStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}
