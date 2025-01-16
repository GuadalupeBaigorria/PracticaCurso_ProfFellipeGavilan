using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCurso.DAL;
using PracticaCurso.DAL.Interfaces;
using PracticaCurso.Models;

namespace PracticaCurso.Controllers
{
    public class CuentasController : Controller
    {
        private readonly IRepositorioCuentas repositorioCuentas;

        public CuentasController(IRepositorioCuentas repositorioCuentas)
        {
            this.repositorioCuentas = repositorioCuentas;
        }

        public IActionResult Index()
        {
            return (IActionResult)View();
        }

        public async Task<IActionResult> Crear(CuentaViewModel cuenta)
        {
            return (IActionResult)View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta(CuentaViewModel cuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(cuenta);
            }
            repositorioCuentas.Crear(cuenta);
            return RedirectToAction("Index");
        }
    }
}
