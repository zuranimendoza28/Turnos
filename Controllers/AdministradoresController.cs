using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using System.Reflection.Metadata.Ecma335;

namespace TurnoAgil.Controllers;

public class AdministradoresController : Controller{
    /* declaramos el context con el modelo para hacer uso de este posteriormente */
    public readonly MisericordiaContext _context;
    public AdministradoresController(MisericordiaContext context){
        _context = context;
    }

    /* Retornamos a la vista del asesor con sus respectivos turnos para que puedan empezar a llamar a cada uno de ellos */
    public async Task<IActionResult> AdminView(){
        return View(await _context.Asesores.ToListAsync());
    }
}