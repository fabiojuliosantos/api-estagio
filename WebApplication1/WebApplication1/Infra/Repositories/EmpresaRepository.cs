using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IDbConnection _conn;

    public EmpresaRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public EmpresaRepository()
    {
    }

    public async Task<List<Empresa>> BuscarTodasEmpresas()
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS";
            var empresas = await _conn.QueryAsync<Empresa>(sql);
            return empresas.ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM EMPRESAS WHERE EMPRESAID = {id}";
            var empresa = await _conn.QueryFirstOrDefaultAsync<Empresa>(sql);
            return empresa;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        string sql = $"INSERT INTO EMPRESAS VALUES (@EMPRESA)";
        var parametros = new 
        { 
            EMPRESA = empresa.Nome
        };
        var empresaCadastrada = await _conn.ExecuteAsync(sql, parametros); 

        return empresaCadastrada > 0 ? true : false;
    }

    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            string sql = "UPDATE EMPRESAS SET NOME=@NOME WHERE EMPRESAID=@ID";
            var parametros = new
            {
                NOME = empresa.Nome,
                ID = empresa.EmpresaID
            };
            var empresaAtualizada = await _conn.ExecuteAsync(sql,parametros);
            return empresaAtualizada > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            string sql = $"DELETE FROM EMPRESAS WHERE EMPRESAID={id}";
            var empresaDeletada = await _conn.ExecuteAsync(sql);
            return empresaDeletada > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
