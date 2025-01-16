using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;
using PracticaCurso.DAL.Interfaces;
using PracticaCurso.Models;
namespace PracticaCurso.DAL
{
    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly string connectionString;

        public RepositorioCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(CuentaViewModel cuenta)
        {
            using var connection = new SqlConnection(connectionString);
            var numeroDeCuenta = await connection.QuerySingleAsync<int>($@"INSERT INTO Cuentas(Numero_de_cuenta, TipoCuenta, Dinero_en_cuenta, Tipo_de_tarjeta,Dinero_disponible_tc)
                                                    VALUES (@NumeroDeCuenta, @TipoCuenta, @DineroEnCuenta, @TipoDeTarjeta, @DineroDisponibleTC);
                                                    ;", cuenta);
            cuenta.NumeroDeCuenta = numeroDeCuenta;
        }

        public async Task<IEnumerable<TipoCuentaViewModel>> ObtenerTiposCuenta()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoCuentaViewModel>(
                @"SELECT * 
                FROM TipoCuenta");
        }
    }
}
