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
    public class VehiculoServicio : IVehiculosServicio
    {
        private readonly IVehiculosRepositorio _vehiculosRepositorio;
        private readonly IMapper _mapper;

        public VehiculoServicio(IVehiculosRepositorio vehiculosRepositorio, IMapper mapper)
        {
            _vehiculosRepositorio = vehiculosRepositorio;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<VehiculoDto>>> ObtenerVehiculos()
        {
            var respuesta = new CustomResponse<List<VehiculoDto>>();
            var vehiculos = await _vehiculosRepositorio.ObtenerVehiculos();
            respuesta.Data = _mapper.Map<List<VehiculoDto>>(vehiculos);
            return respuesta;
        }

        public async Task<CustomResponse<VehiculoDto>> ObtenerVehiculoPorPlaca(string placa)
        {
            var respuesta = new CustomResponse<VehiculoDto>();
            var vehiculo = await _vehiculosRepositorio.ObtenerVehiculoPorPlaca(placa);

            if (vehiculo == null)
            {
                respuesta.EsError = true;
                respuesta.Mensaje = $"Vehículo con placa '{placa}' no encontrado.";
            }
            else
            {
                respuesta.Data = _mapper.Map<VehiculoDto>(vehiculo);
            }

            return respuesta;
        }
    }
}


