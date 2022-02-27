using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeterReading.Data.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<MeterReading> MeterReadings { get; set; }
    }
}
