using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.DAL.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<UsuarioViewModel> BuscarUsuarioPorEmail(string emailNormalizado);
        Task<string> CrearUsuario(UsuarioViewModel usuario);
    }
}
