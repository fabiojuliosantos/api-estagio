using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Mapping
{
    public class EstoqueProfile : Profile
    {
        public EstoqueProfile()
        {
            // Mapeamento de Estoque para EstoqueGetDto
            CreateMap<Estoque, EstoqueGetDto>();

            // Mapeamento de EstoqueDto para Estoque
            CreateMap<EstoqueDto, Estoque>();

            // Mapeamento de EstoqueUpdateDto para Estoque
            CreateMap<EstoqueUpdateDto, Estoque>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))  // Mapeando Nome
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Preco))  // Mapeando Preco
                .ForMember(dest => dest.QtdEstoque, opt => opt.MapFrom(src => src.QtdEstoque));  // Mapeando Quantidade
        }
    }
}
