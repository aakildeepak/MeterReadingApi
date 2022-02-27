using MeterReading.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeterReadingApi.Controllers
{
    [Route("meterreading")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        private readonly IMeterReadingService _meterReadingService;

        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        [HttpPost]
        [Route("meter-reading-uploads")]
        public async Task<IActionResult> Upload(List<IFormFile> file)
        {
            if (file == null || !file.Any())
            {
                return BadRequest("No file found in request");
            }

            var formFile = file.First();
            var fileextension = Path.GetExtension(formFile.FileName);
            if(fileextension == ".csv")
            {
                using (var targetStream = await UploadControllerHelper.BuildMemoryStream(formFile))
                {
                    if (targetStream == null)
                    {
                        return BadRequest();
                    }

                    var uploadResponse = await _meterReadingService.UploadCsv(targetStream);

                    return Ok(uploadResponse);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}