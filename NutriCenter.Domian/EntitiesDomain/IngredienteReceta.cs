using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Domain.EntitiesDomain;

public class IngredienteReceta
{
    public int Id { get; private set; }
    public int RecetaId { get; private set; }
    public string Nombre { get; private set; }
    public decimal Cantidad { get; private set; }
    public string Unidad { get; private set; }

    public IngredienteReceta()
    {
        
    }

    public IngredienteReceta(string nombre, decimal cantidad, string unidad)
    {
        //RecetaId = recetaid;
        Nombre = nombre;
        Cantidad = cantidad;
        Unidad = unidad;
    }

    public override bool Equals(object obj)
    {
        return obj is IngredienteReceta ingrediente &&               
               Nombre == ingrediente.Nombre &&
               Cantidad == ingrediente.Cantidad &&
               Unidad == ingrediente.Unidad;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Cantidad, Unidad);
    }
}
