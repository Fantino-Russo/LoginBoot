using Microsoft.AspNetCore.Mvc;

using LoginBoot.Models;

using Sistema_OT.Models;

namespace LoginBoot.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string id, string contra)
        {
            Usuarios usuario = new Usuarios().encontrarUsuario(id, contra);
            return View();
        }
    }
}
