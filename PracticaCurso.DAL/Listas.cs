using PracticaCurso.Models;

namespace PracticaCurso.DAL
{
    public static class Listas
    {
        public static List<PersonaViewModel> list;

        public static List<PersonaViewModel> GetLista()
        {
            list = new List<PersonaViewModel>();
            list.Add(new PersonaViewModel(1, "Guadalupe", "BE", new DateTime(1995, 09, 19)));
            list.Add(new PersonaViewModel(2, "David", "T", new DateTime(1990, 09, 23)));
            list.Add(new PersonaViewModel(3, "Armando", "Juarez", new DateTime(1986, 09, 05)));

            return list;
        }
    }
}
