﻿using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>().ReverseMap();
    }
}
