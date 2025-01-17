using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCurso.Models
{
    public class CuentasViewModel
    {
        public CuentaViewModel Cuenta { get; set; }
        public List<SelectListItem> TiposDeCuenta { get; set; }
    }
}
