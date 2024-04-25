using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;

namespace TurnoAgil.Controllers;

public class AsesoresController : Controller
{
    public readonly MisericordiaContext _context;
    public AsesoresController(MisericordiaContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Administrador()
    {
        Asesor model = new Asesor();
        model.Nombre = "Josh";
        // return View("Administrador", "Asesores");
        return View(model);
    }
    // public IActionResult Login()
    // {
    //     return View();
    // }
    [HttpPost]
    public  async Task <IActionResult> Login(Asesor model)
    {
        Console.WriteLine($"Este es el NIT: {model.NIT}, password: {model.Password}");
        var asesor = await _context.Asesores.FirstOrDefaultAsync(e => e.NIT == model.NIT && e.Password == model.Password);
        Console.WriteLine($"Este es el asesor {asesor.Nombre}");
        if (asesor != null)
        { if (asesor.NIT == "admin" && asesor.Password == "admin123"){
            return View("AdminView", "Asesores");
        }
            HttpContext.Session.SetString("AserorID", asesor.Id.ToString());
            HttpContext.Session.SetString("AsesorNombre", asesor.Nombre);
            HttpContext.Session.SetString("AsesorNIT", asesor.NIT);
            _context.SaveChanges();
            return RedirectToAction("Administrador");
        }
        else
        {
            ViewBag.Error = "¡Correo o contraseña incorrectos!";
            return View("Index");
        }
    }
}


