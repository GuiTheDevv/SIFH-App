using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIFHApp.Controllers
{
public class HomeController : Controller
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
        Console.WriteLine("controller working");

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(int ReferenceNumber, int VesselID, int CatchID, decimal Weight, int GradeID, decimal Temperature)
    {
        // if (formData == null)
        // {
        //     Console.WriteLine("form no data");
        // }

        FormData formData = new FormData {
            referenceNumber = ReferenceNumber,
            vesselID = VesselID,
            catchID = CatchID,
            weight = Weight,
            gradeID = GradeID,
            temperature = Temperature
        };
        
        // Fetch related entity data based on the provided IDs
        formData.catchName = _context.Products.FirstOrDefault(p => p.ProductId == CatchID)?.ProductName ?? "";
        formData.grade = _context.GradeClasses.FirstOrDefault(g => g.GradeClassId == GradeID)?.GradeClassName ?? "";

        formDataList.Add(
            formData
         );
         
        var viewModel = new FormDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            SubmittedDataList = formDataList
        };

        Console.WriteLine("form submitted");
        foreach(var item in viewModel.SubmittedDataList){
            Console.WriteLine($"ReferenceNumber: {item.referenceNumber}, VesselID: {item.vesselID}, ..."); // Add all properties here
        }


        return View("Index", viewModel);
    }
}


}
