using RH.API.Domain;
using RH.API.Dto;
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
            var erros = Validacoes.ValidarColaborador(colaborador);

            if (erros.Any()) 
            {
                return false; 
            }

            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar colaborador", ex);
        }
    }

    public async Task<RetornoColaborador<ColaboradorGetDto>> BuscarColaboradoresPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarColaboradoresPorPagina(pagina, quantidade);

        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorPorId(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar colaborador por ID", ex);
        }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            return await _repository.BuscarTodosColaboradores();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar todos os colaboradores", ex);
        }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir colaborador", ex);
        }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {

            var erros = Validacoes.ValidarColaborador(colaborador);

            if (erros.Any()) 
            {
                return false; 
            }

            return await _repository.InserirColaborador(colaborador);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao inserir colaborador", ex);
        }
    }
}