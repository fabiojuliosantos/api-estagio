using System.Data;
using Dapper;
using RHAPi.Domain;
using RHAPI.Infra.Interfaces;

namespace RHAPI.Infra.Repositories;

public class ColaboradorRespository : IColaboradorRepository
{
    private readonly IDbConnection _conn;

    public ColaboradorRespository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<Colaborador> BuscarPorId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORID = {id}";
            var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
            return colaborador;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodos()
    {
        try 
        {
            string sql = "SELECT * FROM COLABORADORES";
            var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
            return colaboradores.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Inserir(Colaborador colaborador)
    {
        try 
        {
            string sql = "INSERT INTO COLABORADORES VALUES(@NOME, @CPF, @MATRICULA, @EMPRESAID)";
            var parametros = new 
            {
                NOME = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                EMPRESAID = colaborador.EmpresaID,
            };
            var colaboradorCadastrado =  await _conn.ExecuteAsync(sql, parametros);
            return colaboradorCadastrado > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Atualizar(Colaborador colaborador)
    {
        try
        {
            string sql = "UPDATE COLABORADORES SET NOME = @NOME, CPF = @CPF, MATRICULA = @MATRICULA, EMPRESAID = @EMPRESAID WHERE COLABORADORID = @COLABORADORID";
            var parametros = new 
            {
                NOME = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                EMPRESAID = colaborador.EmpresaID,
                COLABORADORID = colaborador.ColaboradorID
            };
            var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);
            return colaboradorAtualizado > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Deletar(int id)
    {
        try
        {
            string sql = $"DELETE FROM COLABORADORES WHERE COLABORADORID={id}";
            var colaboradorExcluido = await _conn.ExecuteAsync(sql);
            return colaboradorExcluido > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }
}