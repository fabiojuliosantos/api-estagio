using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class EstudanteProfile : Profile
{
    public EstudanteProfile() 
    {
        CreateMap<CreateEstudanteDto, Estudante>().ReverseMap();
    }
}
