using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Models
{
    public class ContactoViewModel
    {
        [Required(ErrorMessage = "Ingrese Id.")]
        [StringLength(maximumLength: 50)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        [StringLength(maximumLength: 50, MinimumLength = 20, ErrorMessage = "Debe ingresar mas de 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Email")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string Email { get; set; }
    }
}
