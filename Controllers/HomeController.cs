using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sifh.ReportGenerator.Model;

namespace SIFH_Application.Controllers;

[ApiController]
[Route("[controller]")]

public class HomeController : Controller
{

    private readonly SifhContext misDbContext;

    public HomeController(SifhContext dbContext)
    {
        this.misDbContext = dbContext;
    }
    [HttpGet("GetAllVessels")]
    public IEnumerable<Vessel> GetVessels(){
        IEnumerable<Vessel> vessels = this.misDbContext.Vessels.ToList();
        return vessels;
    }

    public IActionResult Index()
    {
        return View();
    }
    
}
