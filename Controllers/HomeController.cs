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

    [HttpPost]
    public IActionResult EnviarDatos(Turno datos)
    {
        TempData["DatosFormulario"]=datos;
        return RedirectToAction("Servicio","Home");
    }

    public IActionResult Servicio()
    {
        var datos=TempData["DatosFormulario"] as Turno;
        return View("Servicio", new {Turno=datos, Home="Home"});
    }

    public IActionResult Pantalla()
    {
        return View("Index", "Pantalla");
    }

    public IActionResult Login()
    {
        return View("Index", "Asesores");
    }

    public IActionResult TurnoAsignado()
    {
        return View("TurnoAsignado", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
