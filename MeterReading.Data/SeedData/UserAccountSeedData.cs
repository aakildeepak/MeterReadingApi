using MeterReading.Data.Models;
using System.Collections.Generic;

namespace MeterReading.Data.SeedData
{
    public static class UserAccountSeedData
    {
        public static IEnumerable<UserAccount> Get()
        {
            return new List<UserAccount>()
            {
                new UserAccount { Id = 1, AccountId = 2344, FirstName = "Tommy", LastName = "Test" },
                new UserAccount { Id = 2, AccountId = 2233, FirstName = "Barry", LastName = "Test" },
                new UserAccount { Id = 3, AccountId = 8766, FirstName = "Sally", LastName = "Test" },
                new UserAccount { Id = 4, AccountId = 2345, FirstName = "Jerry", LastName = "Test" },
                new UserAccount { Id = 5, AccountId = 2346, FirstName = "Ollie", LastName = "Test" },
                new UserAccount { Id = 6, AccountId = 2347, FirstName = "Tara", LastName = "Test" },
                new UserAccount { Id = 7, AccountId = 2348, FirstName = "Tammy", LastName = "Test" },
                new UserAccount { Id = 8, AccountId = 2349, FirstName = "Simon", LastName = "Test" },
                new UserAccount { Id = 9, AccountId = 2350, FirstName = "Colin", LastName = "Test" },
                new UserAccount { Id = 10, AccountId = 2351, FirstName = "Gladys", LastName = "Test" },
                new UserAccount { Id = 11, AccountId = 2352, FirstName = "Greg", LastName = "Test" },
                new UserAccount { Id = 12, AccountId = 2353, FirstName = "Tony", LastName = "Test" },
                new UserAccount { Id = 13, AccountId = 2355, FirstName = "Arthur", LastName = "Test" },
                new UserAccount { Id = 14, AccountId = 2356, FirstName = "Craig", LastName = "Test" },
                new UserAccount { Id = 15, AccountId = 6776, FirstName = "Laura", LastName = "Test" },
                new UserAccount { Id = 16, AccountId = 4534, FirstName = "JOSH", LastName = "Test" },
                new UserAccount { Id = 17, AccountId = 1234, FirstName = "Freya", LastName = "Test" },
                new UserAccount { Id = 18, AccountId = 1239, FirstName = "Noddy", LastName = "Test" },
                new UserAccount { Id = 19, AccountId = 1240, FirstName = "Archie", LastName = "Test" },
                new UserAccount { Id = 20, AccountId = 1241, FirstName = "Lara", LastName = "Test" },
                new UserAccount { Id = 21, AccountId = 1242, FirstName = "Tim", LastName = "Test" },
                new UserAccount { Id = 22, AccountId = 1243, FirstName = "Graham", LastName = "Test" },
                new UserAccount { Id = 23, AccountId = 1244, FirstName = "Tony", LastName = "Test" },
                new UserAccount { Id = 24, AccountId = 1245, FirstName = "Neville", LastName = "Test" },
                new UserAccount { Id = 25, AccountId = 1246, FirstName = "Jo", LastName = "Test" },
                new UserAccount { Id = 26, AccountId = 1247, FirstName = "Jim", LastName = "Test" },
                new UserAccount { Id = 27, AccountId = 1248, FirstName = "Pam", LastName = "Test" }
            };
        }
    }
}
