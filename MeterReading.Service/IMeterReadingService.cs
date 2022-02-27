using MeterReading.Service.Models;
using System.IO;
using System.Threading.Tasks;

namespace MeterReading.Service
{
    public interface IMeterReadingService
    {
        Task<UploadResponse> UploadCsv(MemoryStream memoryStream);
    }
}
