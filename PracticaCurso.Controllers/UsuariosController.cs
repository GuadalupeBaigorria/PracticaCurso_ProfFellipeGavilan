using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<UsuarioViewModel> userManager;

        public UsuariosController(UserManager<UsuarioViewModel> userManager) 
        {
            this.userManager = userManager;
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = new UsuarioViewModel() { EmailNormalizado = modelo.Email};

            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

            if(resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach(var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(modelo);
            }

            return RedirectToAction("Registro", "Usuario");
        }
    }
}
