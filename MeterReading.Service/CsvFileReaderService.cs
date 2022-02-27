using CsvHelper;
using MeterReading.Service.Mappers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MeterReading.Service
{
    public class CsvFileReaderService : IFileReaderService
    {
        public IList<Models.MeterReading> ReadFile(MemoryStream memoryStream)
        {
            using var reader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));
            csvReader.Configuration.RegisterClassMap<MeterReadingMap>();
            var records = csvReader.GetRecords<Models.MeterReading>().ToList();

            return records;
        }
    }
}
