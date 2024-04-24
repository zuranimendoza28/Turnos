using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnoAgil.Models;

namespace TurnoAgil.Controllers;

public class AsesoresController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Administrador()
    {
        return View("Administrador", "Asesores");
    }    
}
