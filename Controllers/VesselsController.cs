using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SIFHApp.Models;

namespace SIFHApp.Controllers;

public class VesselsController : Controller
{
    private SifhmisContext dbContext;

    public VesselsController(SifhmisContext db)
    {
        dbContext = db;
    }

    [HttpGet("GetVessels")]
    public IActionResult GetVessels()
    {
        var vessel = dbContext.Vessels.ToList();
        // var fishType = dbContext.Products.ToList();
        return Ok(vessel);
    }

    [HttpGet("GetVesselByID")]
    public IActionResult GetVesselByID(int id)
    {
        var vessel = dbContext.Vessels.Where(x => x.VesselId == id);
        // var fishType = dbContext.Products.ToList();
        return Ok(vessel);
    }
}
