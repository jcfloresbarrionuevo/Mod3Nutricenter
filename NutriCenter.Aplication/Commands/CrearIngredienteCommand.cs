namespace NutriCenter.Aplication.Commands;

public class CrearIngredienteCommand
{
    public CrearIngredienteCommand(string nombre, decimal cantidad, string unidad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Unidad = unidad;
    }

    public string Nombre { get; set; }
    public decimal Cantidad { get; set; }
    public string Unidad { get; set; }
}
