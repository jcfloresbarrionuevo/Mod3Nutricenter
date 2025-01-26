namespace NutriCenter.Domain.EntitiesDomain;

public class PlanAlimentario
{
    public int Id { get; set; }
    public string Nombre { get; private set; }
    public int DuracionDias { get; private set; }
    public string CedulaCliente { get; private set; }
    public string NombreCliente { get; private set; }

    public PlanAlimentario()
    { 

    }
    public PlanAlimentario(string nombreplan, int duracion, string cedula, string cliente)
    {
        Nombre = nombreplan;
        DuracionDias = duracion;
        CedulaCliente = cedula;
        NombreCliente = cliente;        
    }


}
