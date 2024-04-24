using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnoAgil.Models;

namespace TurnoAgil.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Servicio()
    {
        return View("Servicio","Home");
        //return RedirectToAction("Servicio","Home");
    }

     public IActionResult Pantalla()
    {
        return View("Index","Pantalla");
        
    }

    /* public IActionResult Login()
    {
        return View("Index","Asesores");
        
    } */

    public IActionResult TurnoAsignado()
    {
        return View("TurnoAsignado","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
