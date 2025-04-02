using AutoMapper;
using NutriCenter.Aplication.DTOs;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Queries;

public class ObtenerRecetasQueryHandler
{
	private readonly IRecetasRepositorio _repositorio;
	private readonly IMapper _mapper;

	public ObtenerRecetasQueryHandler(IRecetasRepositorio repositorio, IMapper mapper)
	{
		_repositorio = repositorio;
		_mapper = mapper;
	}

	public async Task<List<RecetaDTO>> Handle(ObtenerRecetasQuery query)
	{
		var receta = await _repositorio.ObtenerRecetaAsync();

		if (receta == null || !receta.Any())
		{
			return new List<RecetaDTO>();
		}

		return _mapper.Map<List<RecetaDTO>>(receta);
	}
	//
}
