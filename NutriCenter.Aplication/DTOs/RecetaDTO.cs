namespace NutriCenter.Aplication.DTOs;

public class RecetaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal CostoMonto { get; set; }
    public string CostoMoneda { get; set; }
    public List<IngredientesDTO> Ingredientes { get; set; }
}
