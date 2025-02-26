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

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<Colaborador>> BuscarTodosColaborador()
    {
        try
        {
            var colaborador = await _repository.BuscarTodosColaborador();

            return colaborador;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.InserirColaborador(colaborador);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Colaborador> BuscarColaboradorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorId(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
