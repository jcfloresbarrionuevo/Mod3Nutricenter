using Microsoft.AspNetCore.Mvc;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;

namespace NutriCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoController : ControllerBase
    {
        private readonly CrearTiempoCommandHandler _crearHandler;
        private readonly ObtenerTiempoQueryHandler _obtenerHandler;

        public TiempoController(CrearTiempoCommandHandler crearHandler, ObtenerTiempoQueryHandler obtenerHandler)
        {
            _crearHandler = crearHandler;
            _obtenerHandler = obtenerHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTiempo([FromBody] CrearTiempoCommand command)
        {
            await _crearHandler.Handle(command);
            return Ok("Tiempo creado exitosamente.");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTiempos()
        {
            var tiempos = await _obtenerHandler.Handle(new ObtenerTiempoQuery());
            return Ok(tiempos);
        }
    }
}
