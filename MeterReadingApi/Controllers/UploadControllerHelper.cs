using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MeterReadingApi.Controllers
{
    public static class UploadControllerHelper
    {
        public static async Task<MemoryStream> BuildMemoryStream(IFormFile formFile)
        {
            var targetStream = new MemoryStream();
            await formFile.CopyToAsync(targetStream);
            targetStream.Seek(0, SeekOrigin.Begin);
            return targetStream;
        }
    }
}