using MeterReading.Data.Models;
using MeterReading.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using Reading = MeterReading.Data.Models.MeterReading;

namespace MeterReading.Data.Context
{
    public class MeterReadingContext : DbContext
    {
        public MeterReadingContext()
        {
        }

        public MeterReadingContext(DbContextOptions<MeterReadingContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Reading> MeterReading { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(UserAccountSeedData.Get());
        }
    }
}