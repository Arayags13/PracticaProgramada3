using AutoMapper;
using PracticaProgramada3.BLL.Dtos;
using PracticaProgramada3.DAL.Entidades;
using PracticaProgramada3.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.BLL.Servicios
{
    public class VehiculoServicio 
    {
        private readonly IVehiculosRepositorio _vehiculosRepositorio;
        private readonly IMapper _mapper;

        public VehiculoServicio(IVehiculosRepositorio vehiculosRepositorio, IMapper mapper)
        {
            _vehiculosRepositorio = vehiculosRepositorio;
            _mapper = mapper;
        }

    }
}
