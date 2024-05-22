using DataAccess;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer objManufacturer { get; set; }

        public EditModel(UnitOfWork unitOfWork)  //dependency injection
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            objManufacturer = new Manufacturer();

            //am I in edit mode?
            if (id != 0)
            {
                objManufacturer = _unitOfWork.Manufacturer.GetById(id);
            }

            if (objManufacturer == null)  //nothing found in DB
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
            if (objManufacturer.Id == 0)
            {
                _unitOfWork.Manufacturer.Add(objManufacturer);
                TempData["success"] = "Manufacturer added Successfully";
            }
            //if category exists
            else
            {
                _unitOfWork.Manufacturer.Update(objManufacturer);
                TempData["success"] = "Manufacturer updated Successfully";
            }
            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }

    }
}
