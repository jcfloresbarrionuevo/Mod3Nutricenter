using Microsoft.EntityFrameworkCore;

namespace NutriCenter.Domain.EntitiesDomain;

[Owned]
public class Dinero
{
    public decimal Monto { get; private set; }
    public string Moneda { get; private set; }

    public Dinero(decimal monto, string moneda)
    {
        Monto = monto;
        Moneda = moneda;
    }

    public override bool Equals(object obj)
    {
        return obj is Dinero dinero &&
               Monto == dinero.Monto &&
               Moneda == dinero.Moneda;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Monto, Moneda);
    }
}
