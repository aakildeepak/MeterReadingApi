using CsvHelper;
using MeterReading.Data.Context;
using MeterReading.Service.Mappers;
using MeterReading.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Reading = MeterReading.Service.Models.MeterReading;

namespace MeterReading.Service
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly MeterReadingContext _context;
        private readonly IFileReaderService _fileReaderService;

        public MeterReadingService(MeterReadingContext context, IFileReaderService fileReaderService)
        {
            _context = context;
            _fileReaderService = fileReaderService;
        }

        public async Task<UploadResponse> UploadCsv(MemoryStream memoryStream)
        {
            int successCount = 0;
            var regex = new Regex(@"^[0-9]{5}$");

            try
            {
                var records = _fileReaderService.ReadFile(memoryStream);

                foreach (var item in records)
                {
                    bool validAccount = Int32.TryParse(item.AccountId, out int accountId);
                    bool validDate = DateTime.TryParse(item.MeterReadingDateTime, out DateTime readingDateTime);
                    bool validReadingValue = Int32.TryParse(item.MeterReadingValue, out int readingValue);

                    Match match = regex.Match(item.MeterReadingValue);

                    if (validDate && validReadingValue && readingValue >= 0 && match.Success)
                    {
                        var userAccount = await GetUserAccount(accountId);

                        if (userAccount == null) continue;

                        var meterReading = await GetMeterReading(item);

                        if (meterReading != null) continue;

                        meterReading = new Data.Models.MeterReading()
                        {
                            ReadingDateTime = readingDateTime,
                            ReadingValue = item.MeterReadingValue,
                            UserAccountId = userAccount.Id
                        };

                        await _context.MeterReading.AddAsync(meterReading);
                    }
                }
                successCount = await _context.SaveChangesAsync();

                return new UploadResponse
                {
                    SuccessCount = successCount,
                    FailureCount = records.Count - successCount
                };
            }
            catch (Exception e)
            {
                return new UploadResponse
                {
                    Status = "Failure"
                };
            }
        }

        private async Task<Data.Models.MeterReading> GetMeterReading(Reading item)
        {
            bool validAccount = Int32.TryParse(item.AccountId, out int accountId);
            bool validDate = DateTime.TryParse(item.MeterReadingDateTime, out DateTime readingDateTime);
            bool validReadingValue = Int32.TryParse(item.MeterReadingValue, out int readingValue);

            return await _context.MeterReading.AsNoTracking()
                                    .Where(x => x.UserAccount != null
                                        && x.UserAccount.AccountId == accountId
                                        && x.ReadingDateTime == readingDateTime
                                        && x.ReadingValue == item.MeterReadingValue)
                                    .FirstOrDefaultAsync();
        }

        private async Task<Data.Models.UserAccount> GetUserAccount(int accountId)
        {
            return await _context.UserAccount.AsNoTracking()
                                .Where(user => user.AccountId == accountId)
                                .SingleOrDefaultAsync();
        }
    }
}
