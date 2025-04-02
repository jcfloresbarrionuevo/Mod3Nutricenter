using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Aplication.DTOs;

public class PlanRecetaTiempoDTO
{
	public int Id { get; set; }
	public int PlanAlimentarioId { get; set; }
	public int RecetaId { get; set; }
	public int TiempoComidaId { get; set; }

	public List<PlanAlimentario> PlanAlimentario { get; private set; }
	public List<Receta> Recetas { get; private set; }
	public List<TiempoComida> TiemposComida { get; private set; }
}
