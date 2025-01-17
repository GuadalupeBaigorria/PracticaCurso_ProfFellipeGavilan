using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaCurso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.DAL.Interfaces
{
    public interface IRepositorioCuentas
    {
        Task Crear(CuentaViewModel cuenta);
        Task<IEnumerable<CuentaViewModel>> ObtenerCuentas();
        Task<IEnumerable<TipoCuentaViewModel>> ObtenerTiposCuenta();
    }
}
