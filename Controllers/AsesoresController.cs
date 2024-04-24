using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Data;
using TurnoAgil.Models;

namespace TurnoAgil.Controllers;

public class AsesoresController : Controller
{
    private readonly MisericordiaContext _context;
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
    public IActionResult Login(string nit, string password)
    {
        var asesor = _context.Asesores.FirstOrDefault(e => e.NIT == nit && e.Password == password);
        if (asesor != null)
        {
            // HttpContext.Session.SetString("AserorID", asesor.ID.ToString());
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


