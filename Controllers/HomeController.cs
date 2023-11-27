using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIFHApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SifhmisContext _context;

        public HomeController(SifhmisContext db)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = new DataView
            {
                Vessels = await _context.Vessels.ToListAsync(),
                Products = await _context.Products.ToListAsync(),
                GradeClasses = await _context.GradeClasses.ToListAsync()
            };
            return View(data);
        }
    }
}
