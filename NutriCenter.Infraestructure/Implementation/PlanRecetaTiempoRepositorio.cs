using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Infraestructure.Implementation;

public class PlanRecetaTiempoRepositorio : IPlanRecetaTiempoRepositorio
{
	private readonly AppDbContext _context;

	public PlanRecetaTiempoRepositorio(AppDbContext context)
	{
		_context = context;
	}

	public async Task AgregarPlanRecetaTiempoAsync(List<PlanRecetaTiempo> tc)
	{
		try
		{
			await _context.PlanRecetaTiempo.AddRangeAsync(tc);
			await _context.SaveChangesAsync();
		}
		catch (Exception ex)
		{

			throw;
		}
	}
}
