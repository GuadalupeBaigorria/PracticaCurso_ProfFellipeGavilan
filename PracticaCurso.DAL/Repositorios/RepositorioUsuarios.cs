using Microsoft.Extensions.Configuration;
using PracticaCurso.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaCurso.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace PracticaCurso.DAL.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> CrearUsuario(UsuarioViewModel usuario)
        {
            usuario.EmailNormalizado = usuario.EmailNormalizado.ToUpper();
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"
            INSERT INTO Usuarios (EmailNormalizado, PasswordHash)
            VALUES (@EmailNormalizado, @PasswordHash)
            SELECT SCOPE_IDENTITY();            
            ", usuario);

            return id.ToString();
        }

        public async Task<UsuarioViewModel> BuscarUsuarioPorEmail(string emailNormalizado)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QuerySingleOrDefaultAsync<UsuarioViewModel>(
                "SELECT * FROM Usuarios where EmailNormalizado = @emailNormalizado",
                new { emailNormalizado });
        }
    }
}
