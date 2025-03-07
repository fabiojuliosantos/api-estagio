using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<Livro, CreateLivroDto>().ReverseMap();
    }
}
