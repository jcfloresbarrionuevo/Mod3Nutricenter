namespace NutriCenter.Aplication.Commands;

public class CrearIngredienteCommand
{
    public CrearIngredienteCommand(string Nombre, int Cantidad, string Unidad)
    {
        this.Nombre = Nombre;
        this.Cantidad = Cantidad;
        this.Unidad = Unidad;
    }

    public string? Nombre { get; set; }
    public decimal Cantidad { get; set; }
    public string? Unidad { get; set; }
}
