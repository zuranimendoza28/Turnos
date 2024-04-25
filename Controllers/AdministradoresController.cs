using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;

namespace TurnoAgil.Controllers;

public class AdministradoresController : Controller{
    public readonly MisericordiaContext _context;
    public AdministradoresController(MisericordiaContext context){
        _context = context;
    }
    public IActionResult AdminView(){
        return View();
    }
}