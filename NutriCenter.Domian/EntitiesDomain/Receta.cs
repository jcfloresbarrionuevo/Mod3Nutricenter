using System.Linq;

namespace NutriCenter.Domain.EntitiesDomain;

public class Receta
{
    public int Id { get; private set; }    
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }
    
    public List<IngredienteReceta> Ingredientes { get; private set; }            
    public Dinero Costo { get; private set; }

    public Receta()
    { 
    }

    public Receta(string nombre, string descripcion, Dinero costo)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Ingredientes = new List<IngredienteReceta>();
        Costo = costo;
    }

    public void AgregarIngrediente(IngredienteReceta ingrediente)
    {
        if (!Ingredientes.Contains(ingrediente))
            Ingredientes.Add(ingrediente);                    
    }
}
