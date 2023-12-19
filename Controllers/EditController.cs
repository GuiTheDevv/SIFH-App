using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;


namespace SIFHApp.Controllers
{
public class EditController : Controller
{
    private static List<FormData> formDataList = new List<FormData>(); // Static field to hold form data

    private readonly SifhmisContext _context;

    public EditController(SifhmisContext db)
    {
        _context = db;
    }

        public IActionResult Index(int receivingNoteItemId)
        {
            // Fetch the ReceivingNoteItem based on the provided ID
            ReceivingNoteItem receivingNoteItem = _context.ReceivingNoteItems
                .Include(rni => rni.Product)
                .Include(rni => rni.GradeClass)
                .FirstOrDefault(rni => rni.ReceivingNoteItemId == receivingNoteItemId);

            if (receivingNoteItem == null)
            {
                // Handle the case where the receivingNoteItemId doesn't correspond to any existing item
                return NotFound(); // Or perform a different action based on your application's logic
            }

            ReceivingNote receivingNote = _context.ReceivingNotes.Find(receivingNoteItem.ReceivingNoteId);

            FormData editData = new FormData
            {
                ReferenceNumber = receivingNote.ReferenceNumber,
                VesselID = receivingNote.VesselId,
                CatchID = receivingNoteItem.Product.ProductId,
                CatchName = receivingNoteItem.Product.ProductName,
                Weight = receivingNoteItem.Quantity,
                GradeID = receivingNoteItem.GradeClassId,
                Grade = receivingNoteItem.GradeClass.GradeClassName,
                Temperature = receivingNoteItem.Temperature,
                ImageData = receivingNoteItem.Image
            };

            var editModel = new EditDataViewModel
        {
            Vessels = _context.Vessels.ToList(),
            Products = _context.Products.ToList(),
            GradeClasses = _context.GradeClasses.ToList(),
            Item = editData
        };

            // Pass editData to the Index view for rendering/editing
            return View(editModel);
        }

    // [HttpPost]
    // public async Task<IActionResult> IndexAsync(string ReferenceNumber, int VesselID, int CatchID, decimal Weight, int GradeID, decimal Temperature, IFormFile Image)
    // {
    //     FormData formData = new FormData {
    //         ReferenceNumber = ReferenceNumber,
    //         VesselID = VesselID,
    //         CatchID = CatchID,
    //         Weight = Weight,
    //         GradeID = GradeID,
    //         Temperature = Temperature
    //     };

    //     if(Image != null){
    //             using var memoryStream = new MemoryStream();
    //             await Image.CopyToAsync(memoryStream);
    //             formData.ImageData = memoryStream.ToArray();
    //         } else{
    //             Console.WriteLine("No image");
    //         }
        
        
    //     // Fetch related entity data based on the provided IDs
    //     formData.CatchName = _context.Products.FirstOrDefault(p => p.ProductId == CatchID)?.ProductName ?? "";
    //     formData.Grade = _context.GradeClasses.FirstOrDefault(g => g.GradeClassId == GradeID)?.GradeClassName ?? "";

    //     formDataList.Add(formData); // Add the new form data to the existing static list

    //      var lastFormData = formDataList.LastOrDefault();

    //     var viewModel = new FormDataViewModel
    //     {
    //         Vessels = _context.Vessels.ToList(),
    //         Products = _context.Products.ToList(),
    //         GradeClasses = _context.GradeClasses.ToList(),
    //         SubmittedDataList = formDataList, // Use the static formDataList here
    //         LastReferenceNumber = lastFormData?.ReferenceNumber, // Display last reference number
    //         LastVesselID = lastFormData?.VesselID // Pre-select vessel as the last item in the table
    //     };

    //     Console.WriteLine("form submitted");
    //     foreach(var item in viewModel.SubmittedDataList){
    //         Console.WriteLine($"ReferenceNumber: {item.ReferenceNumber}, file: {item.ImageData} ..."); // Add all properties here
    //     }

    //     return View("Index", viewModel);
    // }
    }
}
