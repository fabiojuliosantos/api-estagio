using AutoMapper;
using RH.API.Domain;

public class EstudanteProfile : Profile
{
    public EstudanteProfile()
    {
        CreateMap<EstudantePutDto, Estudante>()
            .ForMember(dest => dest.Matricula, opt => opt.Ignore()); // Garante que a matrícula não seja alterada
    }
}

