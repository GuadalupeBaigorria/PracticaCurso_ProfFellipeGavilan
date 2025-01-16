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
        [Required(ErrorMessage = "Ingrese Id.")]
        public int NumeroDeCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Cuenta")]
        public string TipoCuenta { get; set; }
        public List<SelectListItem> TiposDeCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero de Cuenta")]
        public double DineroEnCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Tarjeta")]
        [StringLength(maximumLength: 50)]
        public string TipoDeTarjeta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero disponible en Tarjeta de Crédito")]
        public double DineroDisponibleTC { get; set; }
    }
}
