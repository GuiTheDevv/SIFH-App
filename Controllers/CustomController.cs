using Microsoft.AspNetCore.Mvc;
using SIFHApp.Models;


namespace SIFHApp.Controllers
{
public class CustomController : Controller
{
    private static List<ReceivingNote> rn = new List<ReceivingNote>(); // Static field to hold form data
    private static List<ReceivingNoteItem> rnItems = new List<ReceivingNoteItem>(); // Static field to hold form data

    private readonly SifhmisContext _context;

    public CustomController(SifhmisContext db)
    {
        _context = db;
    }

    public IActionResult Index()
    {
        var todayDataView = new TodayDataView {
            receivingNoteItems = rnItems,
            receivingNotes = rn
        };
        Console.WriteLine("controller working");

        return View(todayDataView);
    }

        [HttpPost]
        public IActionResult Index(DateTime datePicker)
        {

            var date = datePicker.Date;

            List<ReceivingNote> receivingNotes = new List<ReceivingNote>();
            List<ReceivingNoteItem> receivingNoteItems = new List<ReceivingNoteItem>();

            receivingNotes = _context.ReceivingNotes.Where(x => x.DateCreated.Date == date).ToList();

            foreach (var rn in receivingNotes)
            {
                var items = _context.ReceivingNoteItems.Where(x => x.ReceivingNoteId == rn.ReceivingNoteId).ToList();
                // foreach (var item in items)
                // {
                //     item.Product = _context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);
                //     item.GradeClass = _context.GradeClasses.FirstOrDefault(x => x.GradeClassId == item.GradeClassId);
                // }
                receivingNoteItems.AddRange(items);
            }

            var todayDataView = new TodayDataView
            {
                receivingNoteItems = receivingNoteItems,
                receivingNotes = receivingNotes
            };

            return View("Index", todayDataView);
        }
    }
}
