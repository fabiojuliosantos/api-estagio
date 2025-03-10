using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<CreateLivroDTO, Livro>().ReverseMap();
        CreateMap<Livro, LivroDTO>().ReverseMap();
    }
}
