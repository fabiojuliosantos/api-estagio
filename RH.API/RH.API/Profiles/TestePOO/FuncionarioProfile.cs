﻿using AutoMapper;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.TestePOO;

namespace RH.API.Profiles.TestePOO;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<CreateFuncionarioDto, Funcionario>().ReverseMap();
    }
}
