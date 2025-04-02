using NutriCenter.Aplication.DTOs;
using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Commands;

public class CrearRecetasCommandHandler
{
	private readonly IRecetasRepositorio _repositorio;

	public CrearRecetasCommandHandler(IRecetasRepositorio repositorio)
	{
		_repositorio = repositorio;
	}

	public async Task Handle(CrearRecetaCommand command)
	{
		var costo = new Dinero(command.CostoMonto, command.CostoMoneda);

		var receta = new Receta(command.Nombre, command.Descripcion, costo);

		foreach (var ingre in command.Ingredientes)
		{
			var ingrediente = new IngredienteReceta(ingre.Nombre, ingre.Cantidad, ingre.Unidad);

			receta.AgregarIngrediente(ingrediente);
		}

		//Guardamos en el repositorio
		await _repositorio.AgregarRecetaAsync(receta);
	}
	//
}
