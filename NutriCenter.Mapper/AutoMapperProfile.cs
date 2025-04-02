using AutoMapper;
using NutriCenter.Aplication.DTOs;
using NutriCenter.Domain.EntitiesDomain;

namespace NutriCenter.Mapper;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		// Mapeo de Receta a RecetaDTO
		CreateMap<Receta, RecetaDTO>()
			.ForMember(dest => dest.Ingredientes, opt => opt.MapFrom(src => src.Ingredientes)).ReverseMap();

		// Mapeo de IngredienteReceta a IngredientesDTO
		CreateMap<IngredienteReceta, IngredientesDTO>().ReverseMap();

		CreateMap<TiempoComidaDTO, TiempoComida>().ReverseMap();

		CreateMap<PlanAlimentarioDTO, PlanAlimentario>().ReverseMap();

		CreateMap<PlanRecetaTiempo, PlanRecetaTiempoDTO>().ReverseMap();
	}
}
