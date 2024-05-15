using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;  //local instance of the database service

        public List<Manufacturer> objManufacturerList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List

        public IndexModel(ApplicationDbContext db)  //dependency injection of the database service
        {
            _db = db;
            objManufacturerList = new List<Manufacturer>();
        }

        public IActionResult OnGet() {
            objManufacturerList = _db.Manufacturers.ToList();
            return Page();
        }
    }
}
