using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NutriCenter.Domain.EntitiesDomain;

public class PlanRecetaTiempo
{
    public int Id { get; private set; }
    public int PlanAlimentarioId { get; private set; }
    public int RecetaId { get; private set; }
    public int TiempoComidaId { get; private set; }
    //
    [NotMapped]
    public List<PlanAlimentario> PlanAlimentario { get; private set; }

    [NotMapped]
    public List<Receta> Recetas { get; private set; }

    [NotMapped]
    public List<TiempoComida> TiemposComida { get; private set; }

    public PlanRecetaTiempo()
    {

    }

    public PlanRecetaTiempo(int plan,int recetaid, int tiempoid)
    {
        PlanAlimentarioId = plan;
        RecetaId = recetaid;
        TiempoComidaId = tiempoid;        
    }
}
