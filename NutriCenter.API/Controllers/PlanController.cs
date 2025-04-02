using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriCenter.Aplication.Commands;
using NutriCenter.Aplication.Queries;

namespace NutriCenter.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlanController : ControllerBase
	{
		private readonly CrearPlanCommandHandler _crearHandler;
		private readonly ObtenerPlanQueryHandler _obtenerHandler;

		public PlanController(CrearPlanCommandHandler crearHandler, ObtenerPlanQueryHandler obtenerHandler)
		{
			_crearHandler = crearHandler;
			_obtenerHandler = obtenerHandler;
		}

		[HttpPost("CrearPlan")]
		public async Task<IActionResult> CrearPlan([FromBody] CrearPlanCommand command)
		{
			await _crearHandler.Handle(command);
			return Ok("Plan creado exitosamente.");
		}

		[HttpGet("ObtenerPlan")]
		public async Task<IActionResult> ObtenerPlan()
		{
			var plan = await _obtenerHandler.Handle(new ObtenerPlanQuery());
			return Ok(plan);
		}
	}
}
