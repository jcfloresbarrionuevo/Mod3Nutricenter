namespace NutriCenter.Aplication.Commands;

public class CrearRecetasTiempos
{
	public CrearRecetasTiempos(int recetaId, string nombreReceta, int tiempoId, string nombreTiempo)
	{
		RecetaId = recetaId;
		NombreReceta = nombreReceta;
		TiempoId = tiempoId;
		NombreTiempo = nombreTiempo;
	}

	public int RecetaId { get; set; }
	public string NombreReceta { get; set; }

	public int TiempoId { get; set; }
	public string NombreTiempo { get; set; }
}
