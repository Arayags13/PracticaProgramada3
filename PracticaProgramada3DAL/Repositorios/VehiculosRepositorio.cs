using PracticaProgramada3.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaProgramada3.DAL.Repositorios
{
    public class VehiculosRepositorio : IVehiculosRepositorio
    {
        private List<Vehiculo> vehiculos = new List<Vehiculo>()
        {
            new Vehiculo { Id = 1, Placa = "BMK-829", Marca = "Toyota", Color = "Blanco", Año = 2020 },
            new Vehiculo { Id = 2, Placa = "ABC-123", Marca = "Honda", Color = "Rojo", Año = 2017 }
        };

        public Task<List<Vehiculo>> ObtenerVehiculos()
        {
            return Task.FromResult(vehiculos);
        }

        public Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa)
        {
            return Task.FromResult(vehiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase)));
        }

        public Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            var nuevoId = vehiculos.Any() ? vehiculos.Max(v => v.Id) + 1 : 1;
            vehiculo.Id = nuevoId;
            vehiculos.Add(vehiculo);
            return Task.FromResult(vehiculo);
        }
        public Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo is null)
                throw new ArgumentNullException(nameof(vehiculo));

            var existente = vehiculos.FirstOrDefault(v =>
                v.Placa.Equals(vehiculo.Placa, StringComparison.OrdinalIgnoreCase));

            if (existente is null)
                throw new KeyNotFoundException($"Vehiculo with placa '{vehiculo.Placa}' not found.");

            existente.Marca = vehiculo.Marca;
            existente.Color = vehiculo.Color;
            existente.Año = vehiculo.Año;


            return Task.FromResult(existente);
        }
    }
}
