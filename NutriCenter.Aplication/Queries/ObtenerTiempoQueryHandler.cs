using AutoMapper;
using NutriCenter.Aplication.DTOs;
using NutriCenter.Infraestructure.Interfaces;

namespace NutriCenter.Aplication.Queries;

public class ObtenerTiempoQueryHandler
{
    private readonly ITiempoComidaRepositorio _repositorio;
    private readonly IMapper _mapper;

    public ObtenerTiempoQueryHandler(ITiempoComidaRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<List<TiempoComidaDTO>> Handle(ObtenerTiempoQuery query)
    {
        var tiempo = await _repositorio.ObtenerTiempoComiAsync();

        if (tiempo==null || !tiempo.Any())
        {
            return new List<TiempoComidaDTO>();
        }

        return _mapper.Map<List<TiempoComidaDTO>>(tiempo);
    }
}
