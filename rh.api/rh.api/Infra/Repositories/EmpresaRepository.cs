using Dapper;
using rh.api.Domain;
using rh.api.Infra.Interfaces;
using System.Data;

namespace rh.api.Infra.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IDbConnection _conn;

    public EmpresaRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
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

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try
        {
            string sql = $"INSERT INTO EMPRESAS VALUES(@EMPRESA)";

            //string sql = string.Format("INSERT INTO EMPRESAS VALUES('{0}')", empresa.Nome);

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
            var empresaAtualizada = await _conn.ExecuteAsync(sql, parametros);

            return empresaAtualizada > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            string sql = string.Format($"DELETE FROM EMPRESAS WHERE EMPRESAID={0}", id);

            var empresaExcluida = await _conn.ExecuteAsync(sql);

            return empresaExcluida > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginadoEmpresa<Empresa>> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS ORDER BY EMPRESAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade
            };

            var empresas  = await _conn.QueryAsync<Empresa>(sql, parametros);

            string quantidadeEmpresaSql = "SELECT COUNT(*) FROM EMPRESAS";

            var qtdDeEmpresas = await _conn.QueryFirstOrDefaultAsync<int>(quantidadeEmpresaSql);

            return new RetornoPaginadoEmpresa<Empresa>
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = qtdDeEmpresas,
                Empresas = empresas.ToList()
            };

        }
        catch (Exception) 
        { throw; }
    }
}
