using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIFHApp.Models;

namespace SIFHApp.Controllers;

public class HomeController : Controller
{
    private readonly SifhmisContext _context;

    public HomeController(SifhmisContext db)
    {
        _context = db;
    }

    public async Task<IActionResult> Index()
    {
        var data = new DataView
        {
            Vessels = await _context.Vessels.ToListAsync(),
            Products = await _context.Products.ToListAsync()
        };
        return View(data);
    }
}
