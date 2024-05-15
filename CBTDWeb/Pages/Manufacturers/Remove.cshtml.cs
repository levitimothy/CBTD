using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class RemoveModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer objManufacturer { get; set; }

        public RemoveModel(ApplicationDbContext db)  //dependency injection
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            objManufacturer = new Manufacturer();

            if (id != 0)
            {
                objManufacturer = _db.Manufacturers.Find(id);
            }

            if (objManufacturer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Manufacturers.Remove(objManufacturer);
            TempData["success"] = "Manufacturer Deleted Successfully";
            _db.SaveChanges();

            return RedirectToPage("./Index");
        }


    }
}
