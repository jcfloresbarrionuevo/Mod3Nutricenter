using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Infraestructure.Interfaces;

public interface IRecetasRepositorio
{
    Task AgregarRecetaAsync(Receta plan);
    Task<List<Receta>> ObtenerRecetaAsync();
}
