using NutriCenter.Aplication.Queries;
using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Commands;

public class CrearTiempoCommandHandler
{
	private readonly ITiempoComidaRepositorio _repositorio;

	public CrearTiempoCommandHandler(ITiempoComidaRepositorio repositorio)
	{
		_repositorio = repositorio;
	}

	public async Task Handle(CrearTiempoCommand command)
	{
		var tiempo = new TiempoComida(command.Nombre, command.Hora);

		await _repositorio.AgregarTiempoComidaAsync(tiempo);
	}
}
