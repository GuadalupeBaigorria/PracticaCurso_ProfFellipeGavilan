using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Models
{
    public class CuentaViewModel
    {
        public CuentaViewModel() { }

        public CuentaViewModel(int numeroDeCuenta, string tipoCuenta, float dineroEnCuenta, string tipoDeTarjeta, float dineroDisponibleTC)
        {
            NumeroDeCuenta = numeroDeCuenta;
            TipoCuenta = tipoCuenta;
            DineroEnCuenta = dineroEnCuenta;
            TipoDeTarjeta = tipoDeTarjeta;
            DineroDisponibleTC = dineroDisponibleTC;
        }

        [Required(ErrorMessage = "Ingrese Id.")]
        public int NumeroDeCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Cuenta")]
        public string TipoCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero de Cuenta")]
        public float DineroEnCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Tarjeta")]
        [StringLength(maximumLength: 50)]
        public string TipoDeTarjeta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero disponible en Tarjeta de Crédito")]
        public float DineroDisponibleTC { get; set; }
    }
}
