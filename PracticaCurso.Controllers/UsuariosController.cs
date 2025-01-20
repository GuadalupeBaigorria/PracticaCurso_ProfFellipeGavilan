using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<UsuarioViewModel> signInManager;

        public UsuariosController(UserManager<UsuarioViewModel> userManager,
            SignInManager<UsuarioViewModel> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var resultado = await signInManager.PasswordSignInAsync(modelo.Email, modelo.Password, modelo.Recuerdame,
                lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Nombre de usuario o contraseña incorrectos");
                return View(modelo);
            }
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
                await signInManager.SignInAsync(usuario, isPersistent: true);
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

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
