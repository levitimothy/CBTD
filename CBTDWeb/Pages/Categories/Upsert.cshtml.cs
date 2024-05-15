using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Categories
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Category objCategory { get; set; }

        public UpsertModel(ApplicationDbContext db)  //dependency injection
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
            objCategory = new Category();

            //am I in edit mode?
            if (id != 0)
            {
                objCategory = _db.Categories.Find(id);
            }

            if (objCategory == null)  //nothing found in DB
            {
                return NotFound();   //built in page
            }

            //assuming I'm in create mode
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if this is a new category
            if (objCategory.Id == 0)
            {
                _db.Categories.Add(objCategory);
                TempData["success"] = "Category added Successfully";
            }
            //if category exists
            else
            {
                _db.Categories.Update(objCategory);
                TempData["success"] = "Category updated Successfully";
            }
            _db.SaveChanges();

            return RedirectToPage("./Index");
        }

    }
}
