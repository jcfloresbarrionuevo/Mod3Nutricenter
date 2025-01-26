using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Infraestructure.Interfaces;

public interface IPlanAlimentarioRepositorio
{
    Task AgregarPlanAsync(PlanAlimentario plan);
    Task<List<PlanAlimentario>> ObtenerPlanAsync();
}
