using PracticaProgramada3.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.DAL.Repositorios
{
    public interface IVehiculosRepositorio
    {
        Task<List<Vehiculo>> ObtenerVehiculos();
        Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa);
        Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo);
        Task<bool> EliminarVehiculo(string placa);

    }
}
