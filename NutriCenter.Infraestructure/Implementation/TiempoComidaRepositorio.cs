using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Infraestructure.Implementation;

public class TiempoComidaRepositorio : ITiempoComidaRepositorio
{
    private readonly AppDbContext _context;

    public TiempoComidaRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task AgregarTiempoComidaAsync(TiempoComida tc)
    {
        try
        {
            await _context.TiempoComida.AddAsync(tc);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<TiempoComida>> ObtenerTiempoComiAsync()
    {
        return await _context.TiempoComida.ToListAsync();
    }


    //
}
