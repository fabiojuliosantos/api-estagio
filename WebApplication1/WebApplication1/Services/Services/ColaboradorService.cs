using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarColaboradorAsync(Colaborador colaborador)
    {
        try
        {
            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception e) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradoresPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscarColaboradoresPorId(id);
        }
        catch (Exception e) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradoresAsync()
    {
        try
        {
            return await _repository.BuscarTodosColaboradores();
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> ExcluirColaboradorAsync(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> InserirColaboradorAsync(Colaborador colaborador)
    {
        try
        {
            return await _repository.InserirColaborador(colaborador);
        }
        catch (Exception e) { throw; }
    }
}
