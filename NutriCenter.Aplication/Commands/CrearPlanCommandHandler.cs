using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Commands;

public class CrearPlanCommandHandler
{
	private readonly IPlanAlimentarioRepositorio _repositorio;
	private readonly IPlanRecetaTiempoRepositorio _repo;

	public CrearPlanCommandHandler(IPlanAlimentarioRepositorio repositorio, IPlanRecetaTiempoRepositorio repo)
	{
		_repositorio = repositorio;
		_repo = repo;
	}

	public async Task Handle(CrearPlanCommand command)
	{
		var plan = new PlanAlimentario(command.Nombre, command.DuracionDias, command.CedulaCliente, command.NombreCliente);

		await _repositorio.AgregarPlanAsync(plan);

		List<PlanRecetaTiempo> detreg = new List<PlanRecetaTiempo>();

		foreach (var reg in command.Detalle)
		{
			var det = new PlanRecetaTiempo(plan.Id, reg.RecetaId, reg.TiempoId);

			detreg.Add(det);
		}

		await _repo.AgregarPlanRecetaTiempoAsync(detreg);
	}
}
