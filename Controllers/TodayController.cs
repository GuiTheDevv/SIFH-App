using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;


namespace SIFHApp.Controllers
{
public class TodayController : Controller
{
    private static List<ReceivingNote> rn = new List<ReceivingNote>();
    // private static List<ReceivingNoteItem> rnItems = new List<ReceivingNoteItem>();

    private readonly SifhmisContext _context;

    public TodayController(SifhmisContext db)
    {
        _context = db;
    }
        public IActionResult Index()
        {
            
             var date = DateTime.Today.AddDays(-1);

                List<ReceivingNote> receivingNotes = new List<ReceivingNote>();

                receivingNotes = _context.ReceivingNotes.Where(x => x.DateCreated.Date == date).ToList();

                var todayDataView = new TodayDataView
                {
                    receivingNotes = receivingNotes,
                    receivingNoteItems = null
                };

                rn = receivingNotes;
                

                return View(todayDataView);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(int receivingNoteId)
        {
            try
            {
                // rnItems.Clear();
                List<ReceivingNoteItem> receivingNoteItems = await _context.ReceivingNoteItems
                    .Where(x => x.ReceivingNoteId == receivingNoteId)
                    .Include(item => item.Product)
                    .Include(item => item.GradeClass)
                    .ToListAsync();

                var dataView = new TodayDataView
                {
                    receivingNotes = rn,
                    receivingNoteItems = receivingNoteItems
                };

                // rnItems = receivingNoteItems; 

                return View("Index", dataView);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

    }

}
