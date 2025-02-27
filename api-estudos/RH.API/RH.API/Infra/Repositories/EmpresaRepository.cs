using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IDbConnection _connection;

    public EmpresaRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS WHERE EMPRESAID = @ID";
            return await _connection.QueryFirstOrDefaultAsync<Empresa>(sql, new { ID = id });
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar empresa por ID.", ex);
        }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresas()
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS";
            var empresas = await _connection.QueryAsync<Empresa>(sql);
            return empresas.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao buscar todas as empresas.", ex);
        }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try
        {
            string sql = @"
            INSERT INTO EMPRESAS (NOME) 
            VALUES (@NOME);";

            var parametros = new { NOME = empresa.Nome };

            var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao inserir empresa.", ex);
        }
    }


    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            string sql = "UPDATE EMPRESAS SET NOME = @NOME WHERE EMPRESAID = @ID";
            var parametros = new { NOME = empresa.Nome, ID = empresa.EmpresaID };

            var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);
            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar empresa.", ex);
        }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            string sql = "DELETE FROM EMPRESAS WHERE EMPRESAID = @ID";
            var linhasAfetadas = await _connection.ExecuteAsync(sql, new { ID = id });
            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao excluir empresa.", ex);
        }
    }
}
