using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Infraestructure.Interfaces;

public interface IPlanRecetaTiempoRepositorio
{
	Task AgregarPlanRecetaTiempoAsync(List<PlanRecetaTiempo> tc);
}
