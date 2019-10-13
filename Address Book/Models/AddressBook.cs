using System.ComponentModel.DataAnnotations;

namespace Address_Book.Models
{
    public class AddressBook
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
