using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Infraestructure.Interfaces;

public interface ITiempoComidaRepositorio
{
	Task AgregarTiempoComidaAsync(TiempoComida tc);
	Task<List<TiempoComida>> ObtenerTiempoComiAsync();
}
