using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;
using TurnoAgil.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using BCrypt.Net;


namespace TurnoAgil.Controllers{
    public class LoginController : Controller{
        public readonly MisericordiaContext _context;
        public LoginController(MisericordiaContext context){
            _context = context;
        }
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(Asesor model){
            var asesor = await _context.Asesores.FirstOrDefaultAsync(e => e.NIT == model.NIT && e.Password == model.Password);
            if (asesor != null){
                if (asesor.NIT == "admin" && asesor.Password == "admin123")
                {
                    HttpContext.Session.SetInt32("userId", asesor.Id);
                    return View("AdminView", "Asesores");
                }

                Response.Cookies.Append("NIT", asesor.NIT.ToString());
                Response.Cookies.Append("Password", asesor.Password.ToString());

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, asesor.NIT),
                    new Claim("Password", asesor.Password),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Administrador", "Asesores");
            }else{

                TempData["Message"] = "Las credenciales son incorrectas";
                return RedirectToAction ("index", "Login");
            }
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("NIT");
            HttpContext.Response.Cookies.Delete("Password");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

    }
}