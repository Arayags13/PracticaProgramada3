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
    public class VehiculosServicio : IVehiculosServicio
    {
        private readonly IVehiculosRepositorio _vehiculosRepositorio;
        private readonly IMapper _mapper;

        public VehiculosServicio(IVehiculosRepositorio vehiculosRepositorio, IMapper mapper)
        {
            _vehiculosRepositorio = vehiculosRepositorio;
            _mapper = mapper;
        }

        public async Task<CustomResponse<List<VehiculoDto>>> ObtenerVehiculos()
        {
            var response = new CustomResponse<List<VehiculoDto>>();

            try
            {
                var lista = await _vehiculosRepositorio.ObtenerVehiculos();
                response.Data = _mapper.Map<List<VehiculoDto>>(lista);
                response.Mensaje = "Vehículos obtenidos correctamente.";
            }
            catch (Exception ex)
            {
                response.EsError = true;
                response.Mensaje = $"Ocurrió un error al obtener los vehículos: {ex.Message}";
            }

            return response;
        }

        public async Task<CustomResponse<VehiculoDto>> ObtenerVehiculoPorPlaca(string placa)
        {
            var response = new CustomResponse<VehiculoDto>();

            try
            {
                var vehiculo = await _vehiculosRepositorio.ObtenerVehiculoPorPlaca(placa);

                if (vehiculo is null)
                {
                    response.EsError = true;
                    response.Mensaje = "No se encontró un vehículo con la placa indicada.";
                    return response;
                }

                response.Data = _mapper.Map<VehiculoDto>(vehiculo);
                response.Mensaje = "Vehículo obtenido correctamente.";
            }
            catch (Exception ex)
            {
                response.EsError = true;
                response.Mensaje = $"Ocurrió un error al obtener el vehículo: {ex.Message}";
            }

            return response;
        }

        public async Task<CustomResponse<VehiculoDto>> CrearVehiculo(VehiculoDto vehiculoDto)
        {
            var response = new CustomResponse<VehiculoDto>();

            try
            {
                if (vehiculoDto == null)
                {
                    response.EsError = true;
                    response.Mensaje = "La información del vehículo es obligatoria.";
                    return response;
                }

                if (string.IsNullOrWhiteSpace(vehiculoDto.Placa))
                {
                    response.EsError = true;
                    response.Mensaje = "La placa es obligatoria.";
                    return response;
                }

                var existente = await _vehiculosRepositorio.ObtenerVehiculoPorPlaca(vehiculoDto.Placa);
                if (existente != null)
                {
                    response.EsError = true;
                    response.Mensaje = "Ya existe un vehículo registrado con esa placa.";
                    return response;
                }

                var entidad = _mapper.Map<Vehiculo>(vehiculoDto);
                var creado = await _vehiculosRepositorio.CrearVehiculo(entidad);

                response.Data = _mapper.Map<VehiculoDto>(creado);
                response.Mensaje = "Vehículo creado correctamente.";
            }
            catch (Exception ex)
            {
                response.EsError = true;
                response.Mensaje = $"Ocurrió un error al crear el vehículo: {ex.Message}";
            }

            return response;
        }

        public async Task<CustomResponse<VehiculoDto>> ActualizarVehiculo(string placa, VehiculoDto vehiculoDto)
        {
            var response = new CustomResponse<VehiculoDto>();

            try
            {
                if (vehiculoDto == null)
                {
                    response.EsError = true;
                    response.Mensaje = "La información del vehículo es obligatoria.";
                    return response;
                }

                var entidad = _mapper.Map<Vehiculo>(vehiculoDto);

                entidad.Placa = placa;

                var actualizado = await _vehiculosRepositorio.ActualizarVehiculo(entidad);

                if (actualizado is null)
                {
                    response.EsError = true;
                    response.Mensaje = "No se encontró un vehículo con la placa indicada.";
                    return response;
                }

                response.Data = _mapper.Map<VehiculoDto>(actualizado);
                response.Mensaje = "Vehículo actualizado correctamente.";
            }
            catch (Exception ex)
            {
                response.EsError = true;
                response.Mensaje = $"Ocurrió un error al actualizar el vehículo: {ex.Message}";
            }

            return response;
        }
        public async Task<CustomResponse<bool>> EliminarVehiculo(string placa)
        {
            var response = new CustomResponse<bool>();

            try
            {
                if (string.IsNullOrWhiteSpace(placa))
                {
                    response.EsError = true;
                    response.Mensaje = "La placa es obligatoria.";
                    return response;
                }

                var eliminado = await _vehiculosRepositorio.EliminarVehiculo(placa);

                if (!eliminado)
                {
                    response.EsError = true;
                    response.Mensaje = "No se encontró un vehículo con la placa indicada.";
                    return response;
                }

                response.Data = true;
                response.Mensaje = "Vehículo eliminado correctamente.";
            }
            catch (Exception ex)
            {
                response.EsError = true;
                response.Mensaje = $"Ocurrió un error al eliminar el vehículo: {ex.Message}";
            }

            return response;
        }

    }
}


