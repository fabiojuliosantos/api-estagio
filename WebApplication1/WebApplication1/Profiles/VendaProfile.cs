using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class VendaProfile : Profile
{
    public VendaProfile()
    {
        CreateMap<Venda, CreateVendaDto>().ReverseMap();
    }
}
