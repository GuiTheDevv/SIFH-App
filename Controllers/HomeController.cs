using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIFHApp.Controllers
{
{
    private List<FormData> formDataList = new List<FormData>(); // Field to hold form data

    private readonly SifhmisContext _context;

    public HomeController(SifhmisContext db)
    {
        _context = db;
    }

    public IActionResult Index()
    {
        var viewModel = new FormDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            SubmittedDataList = formDataList
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SubmitForm(FormData formData)
    {
        // Add submitted data to the list
        if (formData == null)
        {
            formData = new FormData();
        }


        formDataList.Add(
            formData
         );

        return View("Index", formDataList);
    }
}


}
