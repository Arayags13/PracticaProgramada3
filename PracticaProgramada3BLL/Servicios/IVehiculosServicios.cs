using PracticaProgramada3.BLL.Dtos;
using PracticaProgramada3.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.BLL.Servicios
{
    public interface IVehiculosServicios
    {
        Task<List<Vehiculo>> ObtenerVehiculos();
        Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa);
    }
}
