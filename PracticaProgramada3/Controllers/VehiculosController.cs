using Microsoft.AspNetCore.Mvc;
using PracticaProgramada3.BLL.Servicios;
using System.Threading.Tasks;

namespace PracticaProgramada3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculosServicio _vehiculosServicio;

        public VehiculosController(IVehiculosServicio vehiculosServicios)
        {
            _vehiculosServicio = vehiculosServicios;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerVehiculos()
        {
            var respuesta = await _vehiculosServicio.ObtenerVehiculos();

            return Ok(respuesta);
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> ObtenerVehiculoPorPlaca(string placa)
        {
            var respuesta = await _vehiculosServicio.ObtenerVehiculoPorPlaca(placa);

            if (respuesta.EsError)
            {
                return NotFound(respuesta);
            }

            // Retorna un código 200 OK con el vehículo encontrado
            return Ok(respuesta);
        }
    }
}