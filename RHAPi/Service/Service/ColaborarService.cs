using RHAPi.Domain;
using RHAPI.Infra.Interfaces;
using RHAPI.Service.Interfaces;

namespace RHAPI.Service.Service;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }
    public async Task<Colaborador> BucarColaboradorPorId(int id)
    {
        return await _repository.BuscarPorId(id);
    }

    public async Task<List<Colaborador>> BucarTodosColaboradores()
    {
        return await _repository.BuscarTodos();
    }

    public Task<bool> InserirColaborador(Colaborador colaborador)
    {
        return _repository.Inserir(colaborador);
    }

    public Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        return _repository.Atualizar(colaborador);
    }

    public Task<bool> DeletarColaborador(int id)
    {
        return _repository.Deletar(id);
    }
}