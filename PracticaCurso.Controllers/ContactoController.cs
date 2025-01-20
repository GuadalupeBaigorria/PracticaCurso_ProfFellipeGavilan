using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaCurso.Models;
using Microsoft.AspNetCore.Authorization;

namespace PracticaCurso.Controllers
{
    public class ContactoController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
        // GET: ContactoController/Details/5
        public ActionResult Contacto()
        {
            var modelo = new ContactoViewModel() { Nombre = "Guada" };
            return View(modelo);
        }

    }
}
