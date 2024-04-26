using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnoAgil.Data;
using TurnoAgil.Models;

namespace TurnoAgil.Controllers;

public class HomeController : Controller
{
    /* declaramos el context con el modelo para hacer uso de este posteriormente */
    private readonly ILogger<HomeController> _logger;
    private readonly MisericordiaContext _context;

    public HomeController(ILogger<HomeController> logger, MisericordiaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* Creamos la lógica para poder crear y almacenar cada turno y mandarlo a la base de datos  */
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
