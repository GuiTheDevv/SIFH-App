using Microsoft.AspNetCore.Mvc;
using SIFHApp.Models;


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
    public async Task<IActionResult> IndexAsync(string ReferenceNumber, int VesselID, int CatchID, decimal Weight, int GradeID, decimal Temperature, IFormFile Image)
    {
        FormData formData = new FormData {
            ReferenceNumber = ReferenceNumber,
            VesselID = VesselID,
            CatchID = CatchID,
            Weight = Weight,
            GradeID = GradeID,
            Temperature = Temperature
        };

        if(Image != null){
                using var memoryStream = new MemoryStream();
                await Image.CopyToAsync(memoryStream);
                formData.ImageData = memoryStream.ToArray();
            } else{
                Console.WriteLine("No image");
            }
        
        
        // Fetch related entity data based on the provided IDs
        formData.CatchName = _context.Products.FirstOrDefault(p => p.ProductId == CatchID)?.ProductName ?? "";
        formData.Grade = _context.GradeClasses.FirstOrDefault(g => g.GradeClassId == GradeID)?.GradeClassName ?? "";

        formDataList.Add(formData); // Add the new form data to the existing static list

         var lastFormData = formDataList.LastOrDefault();

        var viewModel = new FormDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            SubmittedDataList = formDataList, // Use the static formDataList here
            LastReferenceNumber = lastFormData?.ReferenceNumber, // Display last reference number
            LastVesselID = lastFormData?.VesselID // Pre-select vessel as the last item in the table
        };

        Console.WriteLine("form submitted");
        foreach(var item in viewModel.SubmittedDataList){
            Console.WriteLine($"ReferenceNumber: {item.ReferenceNumber}, file: {item.ImageData} ..."); // Add all properties here
        }

        return View("Index", viewModel);
    }

        [HttpPost]
        public IActionResult InsertFormDataListToDatabase()
        {
            string temp = "";
            try
            {
                foreach (var item in formDataList)
                {
                    if (item.ReferenceNumber != temp)
                    {
                        ReceivingNote rn = new ReceivingNote
                        {
                            ReferenceNumber = item.ReferenceNumber,
                            VesselId = item.VesselID
                        };
                        
                    }



                    formDataList.Clear();

                    // var viewModel = new FormDataViewModel
                    // {
                    //     Vessels = _context.Vessels.ToList(),
                    //     Products = _context.Products.ToList(),
                    //     GradeClasses = _context.GradeClasses.ToList(),
                    //     SubmittedDataList = formDataList, // Use the static formDataList here
                    //     LastReferenceNumber = null, // Display last reference number
                    //     LastVesselID = null // Pre-select vessel as the last item in the table
                    // };

                    Console.WriteLine("Data Saved");

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

            return Ok();
        }
    }
}
