using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Models
{
    public class PersonaViewModel
    {
        public PersonaViewModel() { }
        public PersonaViewModel(int id, string nombre, string apellido, DateTime fechaDeNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaDeNacimiento = fechaDeNacimiento;
        }
        [Required(ErrorMessage = "Ingrese Id.")]
        [StringLength(maximumLength: 50)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Apellido")]
        [StringLength(maximumLength: 50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese Fecha de Nacimiento")]
        [StringLength(maximumLength: 50)]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
