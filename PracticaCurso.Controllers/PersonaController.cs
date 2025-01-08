using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
    }
}
