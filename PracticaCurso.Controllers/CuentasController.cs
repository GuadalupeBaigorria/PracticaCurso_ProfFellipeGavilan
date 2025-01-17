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
using AutoMapper;

namespace PracticaCurso.Controllers
{
    
    public class CuentasController : Controller
    {
        private readonly IRepositorioCuentas repositorioCuentas;
        private readonly IMapper mapper;
        public CuentasController(IRepositorioCuentas repositorioCuentas, IMapper mapper)
        {
            this.repositorioCuentas = repositorioCuentas;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var cuentas = await repositorioCuentas.ObtenerCuentas();
            //var modelo = mapper.Map<IEnumerable<CuentaViewModel>>(cuentas);
            var modelo = new List<CuentaViewModel>();
            foreach (var cuenta in cuentas)
            {
                modelo.Add(new CuentaViewModel
                {
                    NumeroDeCuenta = cuenta.NumeroDeCuenta,
                    TipoCuenta = cuenta.TipoCuenta,
                    DineroDisponibleTC = cuenta.DineroDisponibleTC,
                    DineroEnCuenta = cuenta.DineroEnCuenta,
                    TipoDeTarjeta = cuenta.TipoDeTarjeta
                });
            }

            return View(modelo);
            //return (IActionResult)View();
        }

        public async Task<IActionResult> Crear(CuentaViewModel cuenta)
        {
            CuentasViewModel cuentas = new CuentasViewModel();

            var tiposdecuenta = await repositorioCuentas.ObtenerTiposCuenta();
            cuentas.TiposDeCuenta = tiposdecuenta.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.TipoCuenta.ToString() 
            }).ToList();

            cuentas.Cuenta = new CuentaViewModel();
            cuentas.Cuenta.NumeroDeCuenta = cuenta.NumeroDeCuenta;
            cuentas.Cuenta.TipoDeTarjeta = cuenta.TipoDeTarjeta;
            cuentas.Cuenta.TipoCuenta = cuenta.TipoCuenta;
            cuentas.Cuenta.DineroEnCuenta = cuenta.DineroEnCuenta;
            cuentas.Cuenta.DineroDisponibleTC = cuenta.DineroDisponibleTC;

            return View(cuentas);
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
