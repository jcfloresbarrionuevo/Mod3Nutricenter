using System;
using Microsoft.EntityFrameworkCore;
using NutriCenter.Domain.EntitiesDomain;
using NutriCenter.Infraestructure.DBContext;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Infraestructure.Implementation;

public class PlanAlimentarioRepositorio : IPlanAlimentarioRepositorio
{
	private readonly AppDbContext _context;

	public PlanAlimentarioRepositorio(AppDbContext context)
	{
		_context = context;
	}

	public async Task AgregarPlanAsync(PlanAlimentario plan)
	{
		try
		{
			await _context.PlanAlimentario.AddAsync(plan);
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateException ex)
		{
			throw new InvalidOperationException("No se pudo guardar el plan alimentario en la base de datos.", ex);
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Ocurrió un error inesperado al agregar el plan alimentario.", ex);
		}
	}

	public async Task<List<PlanAlimentario>> ObtenerPlanAsync()
	{
		return await _context.PlanAlimentario.ToListAsync();
	}
}
