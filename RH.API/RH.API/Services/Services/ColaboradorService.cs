using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            var colaboradores = await _repository.BuscarTodosColaboradores();

            return colaboradores;
        }
        catch (Exception) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorPorId(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.InserirColaborador(colaborador);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception) { throw; }
    }
}
