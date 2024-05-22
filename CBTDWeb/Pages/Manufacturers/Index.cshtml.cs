using DataAccess;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;  //local instance of the database service

        public IEnumerable<Manufacturer> objManufacturerList;  //our UI front end will support looping through and displaying Categories retrieved from the database and stored in a List

        public IndexModel(UnitOfWork unitOfWork)  //dependency injection of the database service
        {
            _unitOfWork = unitOfWork;
            objManufacturerList = new List<Manufacturer>();
        }

        public IActionResult OnGet() {
            objManufacturerList = _unitOfWork.Manufacturer.GetAll();
            return Page();
        }
    }
}
