using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ColaboradorDto, Colaborador>();

        CreateMap<Colaborador, ColaboradorGetDto>()
            .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa));

        CreateMap<Empresa, EmpresaDto>();
    }
}
