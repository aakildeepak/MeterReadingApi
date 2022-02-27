using System.Collections.Generic;
using System.IO;
using Reading = MeterReading.Service.Models.MeterReading;

namespace MeterReading.Service
{
    public interface IFileReaderService
    {
        IList<Reading> ReadFile(MemoryStream memoryStream);
    }
}