using Microsoft.AspNetCore.Mvc;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;

namespace NutriCenter.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecetasController : ControllerBase
	{
		private readonly CrearRecetasCommandHandler _crearHandler;
		private readonly ObtenerRecetasQueryHandler _obtenerHandler;

		public RecetasController(CrearRecetasCommandHandler crearHandler, ObtenerRecetasQueryHandler obtenerHandler)
		{
			_crearHandler = crearHandler;
			_obtenerHandler = obtenerHandler;
		}

		[HttpPost("CrearReceta")]
		public async Task<IActionResult> CrearReceta([FromBody] CrearRecetaCommand command)
		{
			await _crearHandler.Handle(command);
			return Ok("Receta creada exitosamente.");
		}

		[HttpGet("ObtenerRecetas")]
		public async Task<IActionResult> ObtenerRecetas()
		{
			var planes = await _obtenerHandler.Handle(new ObtenerRecetasQuery());
			return Ok(planes);
		}
	}
}
