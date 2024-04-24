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
        return View("Administrador", "Asesores");
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Asesor model)
    {
        Console.WriteLine($"Este es el NIT: {model.NIT}");
        var asesor = _context.Asesores.FirstOrDefault(e => e.NIT == model.NIT && e.Password == model.Password);
        if (asesor != null)
        {
            HttpContext.Session.SetString("AserorID", asesor.ID.ToString());
            HttpContext.Session.SetString("AsesorNombre", asesor.Nombre);
            HttpContext.Session.SetString("AsesorNIT", asesor.NIT);
            _context.SaveChanges();
            return RedirectToAction("Administradores");
        }
        else
        {
            ViewBag.Error = "¡Correo o contraseña incorrectos!";
            return View("Index");
        }
    }
}


