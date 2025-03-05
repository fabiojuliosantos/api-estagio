using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<Funcionario, CreateFuncionarioDto>().ReverseMap();
    }
}
