using PracticaProgramada3.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.DAL.Entidades
{
    public class Vehiculo 
    {
        public int Id { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Año { get; set; }
    }
}
