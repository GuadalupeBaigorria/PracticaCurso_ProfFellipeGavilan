using Microsoft.AspNetCore.Mvc;
using PracticasCurso_ProfFelipeGavilan.Models;

namespace PracticasCurso_ProfFelipeGavilan.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: ContactoController/Details/5
        public ActionResult Contacto()
        {
            var modelo = new ContactoViewModel() { Nombre = "Guada" };
            return View(modelo);
        }

    }
}
