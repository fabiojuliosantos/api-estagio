using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class Produto2Profile : Profile
{
    public Produto2Profile()
    {
        CreateMap<CreateProduto2DTO, Produto2>().ReverseMap();
        CreateMap<Produto2, Produto2DTO>().ReverseMap();
    }
}
