using AutoMapper;
using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Profiles;

public class ColaboradorProfile : Profile
{
    public ColaboradorProfile()
    {
        CreateMap<CreateColaboradorDto, Colaborador>().ReverseMap();
    }
}
