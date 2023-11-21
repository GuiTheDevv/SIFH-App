using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using SIFH_Application.Models;

namespace SIFH_Application.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }
}
