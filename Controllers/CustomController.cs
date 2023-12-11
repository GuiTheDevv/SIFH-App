using Microsoft.AspNetCore.Mvc;
using SIFHApp.Models;


namespace SIFHApp.Controllers
{
public class CustomController : Controller
{
    private static List<FormData> formDataList = new List<FormData>(); // Static field to hold form data

    private readonly SifhmisContext _context;

    public CustomController(SifhmisContext db)
    {
        _context = db;
    }

    public IActionResult Index()
    {
        Console.WriteLine("controller working");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(DateTime datePicker)
    {

        var date = datePicker.Date;

        List<ReceivingNote>receivingNotes = new List<ReceivingNote>();
        List<ReceivingNoteItem>receivingNoteItems = new List<ReceivingNoteItem>();

        receivingNotes = _context.ReceivingNotes.Where(x => x.DateCreated.Date == date).ToList();

        foreach(var rn in receivingNotes){
            var items = _context.ReceivingNoteItems.Where(x => x.ReceivingNoteId == rn.ReceivingNoteId).ToList();
            foreach(var item in items){
                item.Product = _context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
                item.GradeClass = _context.GradeClasses.FirstOrDefault(x => x.GradeClassId == item.GradeClassId);
            }
            receivingNoteItems.AddRange(items);
        }

        var todayDataView = new TodayDataView {
            receivingNoteItems = receivingNoteItems,
            receivingNotes = receivingNotes
        };

        return View("Index", todayDataView);
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
