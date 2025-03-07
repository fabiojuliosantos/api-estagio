using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Profiles;

public class BcomProfile : Profile
{
    public BcomProfile() 
    { 
        CreateMap<Bcom, CreateBcomDto>().ReverseMap();
    }
}
