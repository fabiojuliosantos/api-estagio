using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IEstudanteService
{
    RespostaDTO AdicionarEstudante(AdicionarEstudanteDto estudanteDto);

    List<Estudante> ExibirEstudantes();
    RespostaDTO AtualizarMatriculaEstudante(int matricula,Estudante estudante);

}
