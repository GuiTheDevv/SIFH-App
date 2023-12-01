using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SIFHApp.Controllers
{
public class HomeController : Controller
{
    private static List<FormData> formDataList = new List<FormData>(); // Static field to hold form data

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
        FormData formData = new FormData {
            referenceNumber = ReferenceNumber,
            vesselID = VesselID,
            catchID = CatchID,
            weight = Weight,
            gradeID = GradeID,
            temperature = Temperature,
            // image = Image
        };
        
        // Fetch related entity data based on the provided IDs
        formData.catchName = _context.Products.FirstOrDefault(p => p.ProductId == CatchID)?.ProductName ?? "";
        formData.grade = _context.GradeClasses.FirstOrDefault(g => g.GradeClassId == GradeID)?.GradeClassName ?? "";

        formDataList.Add(formData); // Add the new form data to the existing static list

         var lastFormData = formDataList.LastOrDefault();

        var viewModel = new FormDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            SubmittedDataList = formDataList, // Use the static formDataList here
            LastReferenceNumber = lastFormData?.referenceNumber, // Display last reference number
            LastVesselID = lastFormData?.vesselID // Pre-select vessel as the last item in the table
        };

        Console.WriteLine("form submitted");
        foreach(var item in viewModel.SubmittedDataList){
            Console.WriteLine($"ReferenceNumber: {item.referenceNumber}, VesselID: {item.vesselID} ..."); // Add all properties here
        }

        return View("Index", viewModel);
    }
}



}
