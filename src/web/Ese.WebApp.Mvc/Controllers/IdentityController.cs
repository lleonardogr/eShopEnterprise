using Ese.WebApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ese.WebApp.Mvc.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            if (!ModelState.IsValid) return View(usuarioRegistro);
            
            // API-Registro

            if(false)
                return View(usuarioRegistro);

            //Relizar Login na App


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            if (!ModelState.IsValid) return View(usuarioLogin);

            // API-Registro

            if (false)
                return View(usuarioLogin);

            //Relizar Login na App


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
