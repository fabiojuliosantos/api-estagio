using RH.API.Domain.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class EstudanteService : IEstudanteService
{
    public Task<bool> AtualizarMatricula(string Matricula)
    {
        throw new NotImplementedException();
    }

    public Task<List<Estudante>> BuscarTodosEstudantes()
    {
        throw new NotImplementedException();
    }

    public Task<bool> InserirEstudante(Estudante estudante)
    {
        throw new NotImplementedException();
    }
}
