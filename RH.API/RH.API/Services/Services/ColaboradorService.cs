using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;
using RH.API.Validacao;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;
    private readonly IDbConnection _connection;

    public ColaboradorService(IColaboradorRepository repository, IDB)
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
            Validacoes validacao = new();

            var totalColaboradores = "SELECT COUNT(*) FROM COLABORADORES";
            var retornoTotalColaboradores = await _connection.ExecuteScalarAsync<int>(totalColaboradores);

            bool validacaoPagina = validacao.VerificaPaginaEmBranco(pagina, quantidade, retornoTotalColaboradores);

            // Fazer sem retornar 500
            if (validacaoPagina)
                return await _repository.BuscarColaboradoresPorPagina(pagina, quantidade);
            else
                throw new Exception("A página solicitada não possui registros!");
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
            Validacoes validacao = new();
            // Fazer validação para o cpf do colaborador

            bool validacaoCpf = validacao.ValidaCpf(colaborador.Cpf);

            if (validacaoCpf)
                return await _repository.InserirColaborador(colaborador);
            else
                throw new Exception("Cpf inválido!");
        }
        catch (Exception ex) { throw; }
    }
}
