using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        Console.WriteLine("custom controller working");

        return View(todayDataView);
    }

        [HttpPost]
        public IActionResult Index(DateTime startDate, DateTime endDate)
        {
            if(startDate == default && endDate == default){
               Console.WriteLine("invalid date");
            }
            var StartDate = startDate.Date;
            var EndDate = endDate.Date;

            List<ReceivingNote> receivingNotes = new List<ReceivingNote>();
            receivingNotes = _context.ReceivingNotes.Where(x => x.DateCreated.Date >= StartDate && x.DateCreated.Date <= EndDate).ToList();
            rnItems.Clear();
            var todayDataView = new TodayDataView
            {
                receivingNotes = receivingNotes,
                receivingNoteItems = rnItems
            };
            rn = receivingNotes;
            return View("Index", todayDataView);
        }

        [HttpPost]
        public IActionResult Items(int receivingNoteId)
        {
            Console.WriteLine(receivingNoteId);
            List<ReceivingNoteItem> receivingNoteItems = new List<ReceivingNoteItem>();

            receivingNoteItems = _context.ReceivingNoteItems.Where(x => x.ReceivingNoteId == receivingNoteId).ToList();


            receivingNoteItems = _context.ReceivingNoteItems
            .Where(x => x.ReceivingNoteId == receivingNoteId)
            .Include(item => item.Product)
            .Include(item => item.GradeClass)
            .ToList();

            var dataView = new TodayDataView
            {
                receivingNotes = rn,
                receivingNoteItems = receivingNoteItems
            };

            rnItems = receivingNoteItems;

            return RedirectToAction("Index");
        }
    }
}
