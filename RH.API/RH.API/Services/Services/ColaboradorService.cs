using System.Data;
using RH.API.Domain.Entities;
using RH.API.Infra.Interfaces;
using RH.API.Infra.Repositories;
using RH.API.Services.Interface;
using RH.API.Validacao;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;
    private readonly IDbConnection _connection;

    public ColaboradorService(IColaboradorRepository repository, IDbConnection connection)
    {
        _repository = repository;
        _connection = connection;
    }

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<RetornoPaginadoCol<Colaborador>> BuscarColaboradoresPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return  await _repository.BuscarColaboradoresPorPagina(pagina, quantidade);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorPorId(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradoresAsync()
    {
        try
        {
            return await _repository.BuscarTodosColaboradores();
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            Validacoes validacao = new(new ColaboradorRepository(_connection));
            // Fazer validação para o cpf do colaborador

            bool validacaoCpf = await validacao.ValidaCpf(colaborador.Cpf);

            if (validacaoCpf)
                return await _repository.InserirColaborador(colaborador);
            else
                throw new Exception("Cpf inválido!");
        }
        catch (Exception ex) { throw; }
    }
}
