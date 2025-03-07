using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class EstudanteProfile : Profile
{
    public EstudanteProfile()
    {
        CreateMap<Estudante, EstudanteDto>().ReverseMap();
    }
}
