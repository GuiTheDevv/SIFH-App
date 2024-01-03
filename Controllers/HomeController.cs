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
            ProductStatusClasses = _context.ProductStatusClasses.ToList(),
            SubmittedDataList = formDataList
        };

        Console.WriteLine("controller working");

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(string ReferenceNumber, int VesselID, int CatchID, int statusID , decimal Weight, int GradeID, decimal Temperature, IFormFile Image)
    {
        FormData formData = new FormData {
            ReferenceNumber = ReferenceNumber,
            VesselID = VesselID,
            CatchID = CatchID,
            Weight = Weight,
            GradeID = GradeID,
            ProductStatusClassID = statusID,
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
        formData.ProductStatusClassName = _context.ProductStatusClasses.FirstOrDefault(x => x.ProductStatusClassId == statusID)?.ProductStatusClassName ?? "";

        formDataList.Add(formData); // Add the new form data to the existing static list

         var lastFormData = formDataList.LastOrDefault();

        var viewModel = new FormDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            ProductStatusClasses = _context.ProductStatusClasses.ToList(),
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
            try
            {
                foreach (var item in formDataList)
                {
                    Console.WriteLine("Checking");
                    ReceivingNote existingNote = _context.ReceivingNotes.FirstOrDefault(rn => rn.ReferenceNumber == item.ReferenceNumber);
        
                    if (existingNote == null)
                    {
                        Console.WriteLine("Checking passed");
                            ReceivingNote newNote = new ReceivingNote
                            {
                                ReferenceNumber = item.ReferenceNumber,
                                VesselId = item.VesselID,
                                StatusClassId = item.GradeID,
                                DateCreated = DateTime.Now
                            };
            
                            _context.ReceivingNotes.Add(newNote);
                            _context.SaveChanges();
                            Console.WriteLine("Success adding receiving note");

                        ReceivingNoteItem newNoteItem = new ReceivingNoteItem
                        {
                            ReceivingNoteId = _context.ReceivingNotes.Where(x => x.ReferenceNumber == item.ReferenceNumber).FirstOrDefault().ReceivingNoteId,
                            ProductId = item.CatchID,
                            Quantity = item.Weight,
                            UnitPrice = _context.Products.Find(item.CatchID).CurrentUnitPrice,
                            LineTotal = item.Weight * _context.Products.Find(item.CatchID).CurrentUnitPrice,
                            Temperature = item.Temperature,
                            GradeClassId = item.GradeID,
                            ProductStatusClassId = (int)item.ProductStatusClassID,
                            Image = item.ImageData
                        };
        
                        _context.ReceivingNoteItems.Add(newNoteItem);
        
                        Console.WriteLine("success adding item");
        
                        
                    }
                    else
                    {
                        ReceivingNoteItem newNoteItem = new ReceivingNoteItem
                        {
                            ReceivingNoteId = _context.ReceivingNotes.Where(x => x.ReferenceNumber == item.ReferenceNumber).FirstOrDefault().ReceivingNoteId,
                            ProductId = item.CatchID,
                            Quantity = item.Weight,
                            UnitPrice = _context.Products.Find(item.CatchID).CurrentUnitPrice,
                            LineTotal = item.Weight * _context.Products.Find(item.CatchID).CurrentUnitPrice,
                            Temperature = item.Temperature,
                            GradeClassId = item.GradeID,
                            Image = item.ImageData
                        };
        
                        _context.ReceivingNoteItems.Add(newNoteItem);
                        Console.WriteLine("success adding item.");
                    }
                }
        
                // Save changes to the database after processing all items
                _context.SaveChanges();
        
                Console.WriteLine("Data Saved");
        
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            finally
            {
                formDataList.Clear(); // Clear the list in the 'finally' block to ensure it's cleared regardless of exceptions.
            }
        }
    }
}
