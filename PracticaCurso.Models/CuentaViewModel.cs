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
        [StringLength(maximumLength: 50)]
        public int NumeroDeCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Cuenta")]
        [StringLength(maximumLength: 50)]
        public string TipoCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero de Cuenta")]
        [StringLength(maximumLength: 50)]
        public double DineroEnCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese Tipo de Tarjeta")]
        [StringLength(maximumLength: 50)]
        public string TipoDeTarjeta { get; set; }

        [Required(ErrorMessage = "Ingrese Dinero disponible en Tarjeta de Crédito")]
        [StringLength(maximumLength: 50)]
        public double DineroDisponibleTC { get; set; }
    }
}
