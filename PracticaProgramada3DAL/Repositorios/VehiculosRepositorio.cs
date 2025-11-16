using PracticaProgramada3.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.DAL.Repositorios
{
    public  class VehiculosRepositorio : IVehiculosRepositorio
    {       
   
        private List<Vehiculo> vehiculos = new List<Vehiculo>()
        {
            new Vehiculo { Id = 1, Placa = "BMK-829", Marca = "Toyota", Color = "Blanco", Año =2020 },
            new Vehiculo { Id = 1, Placa = "ABC-123", Marca = "Honda", Color = "Rojo", Año =2017 }
        };

        public Task<List<Vehiculo>> ObtenerVehiculos()
        {
            return Task.FromResult(vehiculos);
        }

        public Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa)
        {
            return Task.FromResult(vehiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
