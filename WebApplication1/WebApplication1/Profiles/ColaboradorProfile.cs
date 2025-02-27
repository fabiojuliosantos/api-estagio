using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class ColaboradorProfile : Profile
{
    public ColaboradorProfile()
    {
        CreateMap<Colaborador, CreateColaboradorDto>().ReverseMap();
        CreateMap<Colaborador, UpdateColaboradorDto>().ReverseMap();
    }
}
