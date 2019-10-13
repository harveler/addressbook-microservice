using Address_Book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace Address_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private readonly AddressBookDbContext _context;

        public AddressBookController(AddressBookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            // Enables ToTitleCase to be used on City to overcome case-sensitivity
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;

            var addresses = _context.AddressBook.GroupBy(c => textInfo.ToTitleCase(c.City))
                                        .ToDictionary(g => g.Key, g => g.ToList());

            return Ok(addresses);
        }
    }
}
