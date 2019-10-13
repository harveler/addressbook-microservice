using Address_Book.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book.Models
{
    public class AddressBookDbContext: DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options) : base(options) {}

        public DbSet<AddressBook> AddressBook { get; set; }
    }
}
