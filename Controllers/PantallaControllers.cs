using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace TurnoAgil.Controllers;

public class PantallaController : Controller
{
    public readonly MisericordiaContext _context;

    public PantallaController(MisericordiaContext context)
    {
        _context = context;
    }

    /*public IActionResult Index()
    {
        return View();
    }*/

    /* public async Task<IActionResult> Index()
        {
           //return Json(await _context.Turnos.ToListAsync());
           return View(await _context.Turnos.ToListAsync());
           
        } */




public async Task<IActionResult> Index()
{
    var ultimosTurnos = await _context.Turnos
                                    .OrderByDescending(t => t.FechaSolicitud)
                                    .Skip(0)
                                    .Take(6)
                                    .ToListAsync();

    return View(ultimosTurnos);
}





}