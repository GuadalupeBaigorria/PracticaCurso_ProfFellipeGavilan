using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PracticaCurso.DAL.Interfaces;
using PracticaCurso.Models;
namespace PracticaCurso.DAL
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<RepositorioCuentas, CuentaViewModel>();
        }
    }
}
