namespace NutriCenter.Aplication.DTOs;

public class PlanAlimentarioDTO
{
	public int Id { get; set; }
	public string? Nombre { get; set; }
	public int DuracionDias { get; set; }
	public string CedulaCliente { get; set; }
	public string NombreCliente { get; set; }
}
