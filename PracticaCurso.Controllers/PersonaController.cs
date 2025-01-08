using Microsoft.AspNetCore.Mvc;
using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCurso.DAL;
namespace PracticaCurso.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return (IActionResult)View();
        }

        public async Task Crear(PersonaViewModel persona)
        {
            if (Listas.list.Where(x => x.Id == persona.Id).Any())
            {
               Listas.list.Add(persona); 
            }
        }

        public async Task<IActionResult> ListadoPersona()
        {
            return View(Listas.GetLista());
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            return View(Listas.GetLista().Where(x => x.Id == id).SingleOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult> Editar(PersonaViewModel persona)
        {
            Listas.GetLista().Where(x => x.Id == persona.Id).SingleOrDefault().Nombre = persona.Nombre;
            Listas.GetLista().Where(x => x.Id == persona.Id).SingleOrDefault().Apellido = persona.Apellido;
            Listas.GetLista().Where(x => x.Id == persona.Id).SingleOrDefault().FechaDeNacimiento = persona.FechaDeNacimiento;

            return RedirectToAction("ListadoPersona");
        }
    }
}
