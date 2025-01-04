using System.ComponentModel.DataAnnotations;

namespace PracticasCurso_ProfFelipeGavilan.Models
{
    public class ContactoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese Id.")]
        [StringLength(maximumLength: 50)]

        public string Nombre { get; set; }
        [Required]

        public string Email { get; set; }
        //[Required]
        //[StringLength(maximumLength: 60)]
    }
}
