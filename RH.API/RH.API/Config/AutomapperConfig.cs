using AutoMapper;
using RH.API.Domain.Entities;
using RH.API.DTOs;

namespace RH.API.Config
{
    // para mapeamento automático
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
            CreateMap<Funcionario, CreateFuncionarioDTO>().ReverseMap();
        }
    }
}
