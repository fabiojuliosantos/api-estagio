using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto,CreateProdutoDto>().ReverseMap();
        CreateMap<Produto,UpdateProdutoDto>().ReverseMap();
    }
}
