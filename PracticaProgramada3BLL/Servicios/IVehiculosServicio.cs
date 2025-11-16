using PracticaProgramada3.BLL.Dtos;
using PracticaProgramada3.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.BLL.Servicios
{
    public interface IVehiculosServicio
    {
        Task<CustomResponse<List<VehiculoDto>>> ObtenerVehiculos();
        Task<CustomResponse<VehiculoDto>> ObtenerVehiculoPorPlaca(string placa);
        Task<CustomResponse<VehiculoDto>> CrearVehiculo(VehiculoDto vehiculo);
        Task<CustomResponse<VehiculoDto>> ActualizarVehiculo(string placa, VehiculoDto vehiculo);
        Task<CustomResponse<bool>> EliminarVehiculo(string placa);

    }
}
