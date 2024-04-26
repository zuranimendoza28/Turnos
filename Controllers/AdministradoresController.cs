using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using System.Reflection.Metadata.Ecma335;

namespace TurnoAgil.Controllers;

public class AdministradoresController : Controller{
    public readonly MisericordiaContext _context;
    public AdministradoresController(MisericordiaContext context){
        _context = context;
    }
    public async Task<IActionResult> AdminView(){
        return View(await _context.Asesores.ToListAsync());
    }
}