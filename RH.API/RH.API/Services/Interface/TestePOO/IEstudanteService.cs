using RH.API.Domain.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface IEstudanteService
{
    Task<bool> InserirEstudante(Estudante estudante);
    Task<List<Estudante>> BuscarTodosEstudantes();
    Task<bool> AtualizarMatricula(string Matricula);
}
