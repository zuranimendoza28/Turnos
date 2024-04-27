using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TurnoAgil.Controllers;
[Authorize]
public class AsesoresController : Controller
{
    /* declaramos el context con el modelo para hacer uso de este posteriormente */
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
        return View(model);
    }
    
    [HttpPost]
    public async Task <IActionResult> Login(Asesor model)
    {
        var asesor = await _context.Asesores.FirstOrDefaultAsync(e => e.NIT == model.NIT && e.Password == model.Password);
        if (asesor != null)
        { if (asesor.NIT == "admin" && asesor.Password == "admin123"){
            return View("AdminView", "Asesores");
        }
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



