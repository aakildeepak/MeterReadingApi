namespace MeterReading.Service.Models
{
    public class UploadResponse
    {
        public string Status { get; set; } = "Success";
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
}
