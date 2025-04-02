using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Aplication.DTOs;

public class IngredientesDTO
{
	public int Id { get; set; }
	public int RecetaId { get; set; }
	public string Nombre { get; set; }
	public decimal Cantidad { get; set; }
	public string Unidad { get; set; }
}
