using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnoAgil.Data;
using TurnoAgil.Models;

namespace TurnoAgil.Controllers;

public class HomeController : Controller
{
    /* declaramos el context con el modelo para hacer uso de este posteriormente */
    private readonly ILogger<HomeController> _logger;
    private readonly MisericordiaContext _context;

    public HomeController(ILogger<HomeController> logger, MisericordiaContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    /* [HttpPost]
    public IActionResult EnviarDatos(Turno datos)
    {
        TempData["DatosFormulario"]=datos;
        return RedirectToAction("Servicio","Home");
    } 

    public IActionResult Servicio()
    {
        var datos=TempData["DatosFormulario"] as Turno;
        return View("Servicio", new {Turno=datos, Home="Home"});
    }   */ 

    public IActionResult GuardarPrimerosDatos(string TipoDocumento,string Documento){
        if(Documento!=null){
            HttpContext.Session.SetString("documentoSession", Documento);
            HttpContext.Session.SetString("tipoDocumentoSession", TipoDocumento);
            return RedirectToAction("Servicio");
        }else{
            return RedirectToAction("Index");
        }
    }

    public IActionResult Guardar(string turno){
        int contador = Request.Cookies.ContainsKey("Contador")? int.Parse(Request.Cookies["Contador"]): 0; /* verifica si existe contador */
        contador++;

        string ticket=$"{turno}-{(contador<10 ? "00" + contador:"0"+contador)}";/* Ticket para la persona y se muestra en pantalla numero del ticket actual*/
    
        Response.Cookies.Append("Contador", contador.ToString()); /* se agrega el contador a la cookie */

        HttpContext.Session.SetString("servicioSession", turno);

        ViewBag.ticket = ticket;

        var ArrayTicket = ticket.Split("-");
        var numeroticket = int.Parse(ArrayTicket[1]);

        var turnito=new Turno(){
            Servicio = turno,
            NumeroTurno = numeroticket,
            TipoDocumento = HttpContext.Session.GetString("tipoDocumentoSession"),
            Documento = HttpContext.Session.GetString("documentoSession"),
            FechaSolicitud = DateTime.Now,
            FechaInicioAtencion = null,
            FechaFinAtencion = null
        };

        _context.Turnos.Add(turnito);
        _context.SaveChanges();

        return View("TurnoAsignado");   
    }

    public IActionResult Servicio(){
        return View();
    }

    public IActionResult Pantalla()
    {
        return View("Index", "Pantalla");
    }

    /* Ticket que se le muestra al usuario para que vea el turno y el la hora en la cual se hizo la solicitud del turno */
    public IActionResult TurnoAsignado()
    {
        return View("TurnoAsignado", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
