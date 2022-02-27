using System;
using System.ComponentModel.DataAnnotations;

namespace MeterReading.Data.Models
{
    public class MeterReading
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public string ReadingValue { get; set; }
        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}
