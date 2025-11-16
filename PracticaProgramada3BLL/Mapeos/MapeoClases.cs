using PracticaProgramada3.DAL.Entidades;
using PracticaProgramada3.BLL.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaProgramada3.BLL.Mapeos
{
    public class MapeoClases : Profile
    {
        public MapeoClases() 
        {
            CreateMap<Vehiculo, VehiculoDto>();
            CreateMap<VehiculoDto, Vehiculo>();
        }
        
    }
}
