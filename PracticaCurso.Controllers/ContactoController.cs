using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticaCurso.Models;

namespace PracticaCurso.Controllers
{
    public class ContactoController : Controller
    {
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
