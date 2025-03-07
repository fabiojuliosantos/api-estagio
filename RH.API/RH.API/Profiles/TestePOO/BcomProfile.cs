using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class BcomProfile : Profile
{
    public BcomProfile()
    {
        CreateMap<CreateBcomDto, Bcom>().ReverseMap();
    }
}
