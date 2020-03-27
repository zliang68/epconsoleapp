using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvFileLib.Services
{
    /// <summary>
    /// Make it unit testable
    /// </summary>
    public interface IFileStreamReader
    {
        StreamReader GetStreamReader(string path);
    }
}
