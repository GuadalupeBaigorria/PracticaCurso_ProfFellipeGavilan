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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

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
            var tiposdecuenta = await repositorioCuentas.ObtenerTiposCuenta();

            cuenta.TiposDeCuenta = tiposdecuenta
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.TipoCuenta
                })
                .ToList();

            return View(cuenta);
            //return RedirectToAction("Index");
            //return View();
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

        [HttpPost]
        public async Task<IActionResult> ObtenerTipoCuentas(int cuentaId)
        {
            var tiposDeCuenta = await repositorioCuentas.ObtenerTiposCuenta();
            var listaItems = tiposDeCuenta.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(), // Suponiendo que Id es la propiedad de clave
                Text = c.TipoCuenta // Suponiendo que Nombre es la propiedad a mostrar
            }).ToList();

            return View(listaItems);
        }
    }
}
