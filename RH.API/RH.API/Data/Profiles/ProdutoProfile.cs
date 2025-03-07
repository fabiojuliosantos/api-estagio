using AutoMapper;
using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Data.Profiles;


public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CriarProdutoDto, Produtos>();
        CreateMap<AdicionarEstudanteDto, Estudante>();
    }
}
