using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Infraestructure.Implementation;

public class RecetasRepositorio:IRecetasRepositorio
{
    private readonly AppDbContext _context;

    public RecetasRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task AgregarRecetaAsync(Receta rec)
    {
        try
        {
            await _context.Receta.AddAsync(rec);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public async Task<List<Receta>> ObtenerRecetaAsync()
    {
        return await _context.Receta.Include(p => p.Ingredientes).ToListAsync();
    }
}
