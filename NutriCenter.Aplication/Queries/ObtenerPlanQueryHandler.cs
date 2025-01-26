using AutoMapper;
using NutriCenter.Aplication.DTOs;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Queries;

public class ObtenerPlanQueryHandler
{
    private readonly IPlanAlimentarioRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ObtenerPlanQueryHandler(IPlanAlimentarioRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<List<PlanAlimentarioDTO>> Handle(ObtenerPlanQuery query)
    {
        var plan = await _repositorio.ObtenerPlanAsync();

        if (plan == null || !plan.Any())
        {
            return new List<PlanAlimentarioDTO>();
        }

        return _mapper.Map<List<PlanAlimentarioDTO>>(plan);
    }
}
