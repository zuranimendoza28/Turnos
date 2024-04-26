using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace TurnoAgil.Controllers;
public class PantallaController : Controller
{
    /* declaramos el context con el modelo para hacer uso de este posteriormente */
    public readonly MisericordiaContext _context;
    public PantallaController(MisericordiaContext context){
        _context = context;
    }    

    /* Declaramos el método necesario para poder traer de la base de datos los turnos actualmente llamados y los siguientes en cola */
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