using Address_Book.Models;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book.Data
{
    public class DbInitializer
    {
        public static void Seed(AddressBookDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.AddressBook.Any())
            {
                return;
            }

            List<AddressBook> addresses = new List<AddressBook>
            {
                new AddressBook { FirstName = "John", LastName = "Smith", StreetAddress = "Test St 1", City= "London", Country = "England" },
                new AddressBook { FirstName = "Jane", LastName = "Doe", StreetAddress = "Test St 2", City= "london", Country = "England" },
                new AddressBook { FirstName = "Tim", LastName = "Jones", StreetAddress = "Test St 3", City= "New York", Country = "USA" }
            };

            foreach (AddressBook address in addresses)
            {
                context.AddressBook.Add(address);
            }
            context.SaveChanges();
        }
    }
}
