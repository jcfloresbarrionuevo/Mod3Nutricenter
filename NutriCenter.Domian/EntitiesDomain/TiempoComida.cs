namespace NutriCenter.Domain.EntitiesDomain;

public class TiempoComida
{
    public int Id { get; set; }    
    public string Nombre { get; private set; }
    public TimeSpan Hora { get; private set; }

    public TiempoComida(string nombre, TimeSpan hora)
    {
        Nombre = nombre;
        Hora = hora;
    }

    public override bool Equals(object obj)
    {
        return obj is TiempoComida tiempo &&
               Nombre == tiempo.Nombre &&
               Hora.Equals(tiempo.Hora);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Hora);
    }
}
