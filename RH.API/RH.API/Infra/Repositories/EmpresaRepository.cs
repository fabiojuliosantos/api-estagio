using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using System.Data;

namespace RH.API.Infra.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IDbConnection _conn;

    public EmpresaRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<Empresa> BuscarEmpresaPorIdAsync(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM EMPRESAS WHERE EMPRESAID={id}";
            var empresa = await _conn.QueryFirstOrDefaultAsync<Empresa>(sql);
            return empresa;
        }
        catch (Exception)
        {
            throw;
        }
    }

    

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
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

    public async Task<bool> InserirEmpresaAsync(Empresa empresa)
    {
        try
        {
            string sql = $"INSERT INTO EMPRESAS VALUES(@EMPRESA)";

            var parametros = new
            {
                EMPRESA = empresa.Nome
            };

            var empresaCadastrada = await _conn.ExecuteAsync(sql, parametros);

            return empresaCadastrada > 0 ? true : false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarEmpresaAsync(Empresa empresa)
    {
        try
        {
            string sql = "UPDATE EMPRESAS SET NOME=@NOME WHERE EMPRESAID=@ID";
            var parametros = new
            {
                NOME = empresa.Nome,
                ID = empresa.EmpresaID
            };
            var empresaAtualizada = await _conn.ExecuteAsync(sql, parametros);

            return empresaAtualizada > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirEmpresaAsync(int id)
    {
        try
        {
            string sql = string.Format("DELETE FROM EMPRESAS WHERE EMPRESAID={0}", id);

            var empresaExcluida = await _conn.ExecuteAsync(sql);

            return empresaExcluida > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

}
