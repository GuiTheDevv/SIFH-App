using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;


namespace SIFHApp.Controllers
{
public class EditController : Controller
{
    private static int rniID;

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

            rniID = receivingNoteItem.ReceivingNoteItemId;

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

        [HttpPost]
        public IActionResult EditItem(string ReferenceNumber, int VesselID, int CatchID, decimal Weight, int GradeID, decimal Temperature, IFormFile Image)
        {
            try
            {
                Console.WriteLine(rniID);
            Console.WriteLine(ReferenceNumber);
            Console.WriteLine( VesselID);
            Console.WriteLine( CatchID);
            Console.WriteLine( Weight);
                // var rnID = _context.ReceivingNoteItems.Find(rniID).ReceivingNoteId;
                // ReceivingNote rn = _context.ReceivingNotes.Find(rnID);

                // rn.ReferenceNumber = ReferenceNumber;
                // rn.VesselId = VesselID;

                // ReceivingNoteItem rni = _context.ReceivingNoteItems.Find(rniID);

                // rni.ProductId = CatchID;
                // rni.Quantity = Weight;
                // rni.UnitPrice = _context.Products.Find(CatchID).CurrentUnitPrice;
                // rni.LineTotal = Weight * _context.Products.Find(CatchID).CurrentUnitPrice;
                // rni.Temperature = Temperature;
                // rni.GradeClassId = GradeID;
                // if(Image != null){
                //     using var memoryStream = new MemoryStream();
                //     await Image.CopyToAsync(memoryStream);
                //     rni.Image = memoryStream.ToArray();
                // } else{
                //     Console.WriteLine("No image");
                // }

                // _context.Update(rn);
                // _context.Update(rni);
                // _context.SaveChanges();


                return RedirectToAction("Index", "Today");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
