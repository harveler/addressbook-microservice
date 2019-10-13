using System.Collections.Generic;
using System.Linq;
using Address_Book.Controllers;
using Address_Book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AddressBookTests
{
    public class AddressBookTests
    {
        [Fact]
        public void Get_ReturnsGroupedValues()
        {
            // arrange
            var options = new DbContextOptionsBuilder<AddressBookDbContext>()
                .UseInMemoryDatabase(databaseName: "AddressBook")
                .Options;

            using(var context = new AddressBookDbContext(options))
            {
                context.AddressBook.Add(new AddressBook { FirstName = "Jane", LastName = "Jones", StreetAddress = "Test Rd 1", City = "Rome", Country = "Italy" });
                context.AddressBook.Add(new AddressBook { FirstName = "Tim", LastName = "Smith", StreetAddress = "Test Rd 2", City = "Paris", Country = "France" });
                context.AddressBook.Add(new AddressBook { FirstName = "John", LastName = "Doe", StreetAddress = "Test Rd 3", City = "Paris", Country = "France" });
                context.SaveChanges();
            }

            using(var context = new AddressBookDbContext(options))
            {
                // act
                var controller = new AddressBookController(context);
                OkObjectResult result = controller.Get() as OkObjectResult;
                var content = result.Value as IDictionary<string, List<AddressBook>>;

                // assert
                Assert.Equal(3, context.AddressBook.Count());
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, result.StatusCode);
                Assert.Equal(2, content.Count());
            }
        }

        [Fact]
        public void Get_ReturnsEmptyObject()
        {
            // arrange
            var options = new DbContextOptionsBuilder<AddressBookDbContext>()
                .UseInMemoryDatabase(databaseName: "AddressBook")
                .Options;

            using(var context = new AddressBookDbContext(options))
            {
                // act
                var controller = new AddressBookController(context);
                OkObjectResult result = controller.Get() as OkObjectResult;
                var content = result.Value as IDictionary<string, List<AddressBook>>;

                // assert
                Assert.Empty(context.AddressBook);
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, result.StatusCode);
                Assert.Empty(content);
            }
        }
    }
}