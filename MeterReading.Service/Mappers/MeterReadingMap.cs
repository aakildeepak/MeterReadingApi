using CsvHelper.Configuration;
using Reading = MeterReading.Service.Models.MeterReading;
namespace MeterReading.Service.Mappers
{
    public sealed class MeterReadingMap : ClassMap<Reading>
    {
        public MeterReadingMap()
        {
            Map(x => x.AccountId).Name("AccountId");
            Map(x => x.MeterReadingDateTime).Name("MeterReadingDateTime");
            Map(x => x.MeterReadingValue).Name("MeterReadValue");
        }
    }
}