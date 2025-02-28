using System.ComponentModel.Design;
using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly IDbConnection _conn;

    public ColaboradorRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = "UPDATE COLABORADORES SET NOME=@NOME,CPF=@CPF,MATRICULA=@MATRICULA WHERE COLABORADORID=@COLABORADORID";
            var parametros = new
            {
                NOME = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                COLABORADORID = colaborador.ColaboradorID
            };
            var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);
            return colaboradorAtualizado > 0 ? true : false;
        }
        catch (Exception e) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradoresPorId(int id)
    {
        try
        {
            string sql = @$"SELECT TOP 1 C.*,E.NOME AS NomeDaEmpresa
            FROM COLABORADORES C
            INNER JOIN EMPRESAS E
            ON C.EMPRESAID = E.EMPRESAID
            WHERE COLABORADORID={id}";
            return await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
        }
        catch (Exception e) { throw; }
    }

    public async Task<RetornoColaboradorPaginado<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int quantidade)
    {

        try
        {
            string sql = @"SELECT C.*,E.NOME AS NomeDaEmpresa
            FROM COLABORADORES C
            INNER JOIN EMPRESAS E
            ON C.EMPRESAID = E.EMPRESAID
            ORDER BY COLABORADORID
            OFFSET @OFFSET ROWS FETCH NEXT @FETCHNEXT ROWS ONLY";
            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                FETCHNEXT = quantidade
            };
            var empresas = await _conn.QueryAsync<Colaborador>(sql, parametros);

            string sqlQuantidadeColaboradores = "SELECT COUNT(*) FROM COLABORADORES";

            var quantidadeColaboradores = await _conn.QueryFirstOrDefaultAsync<int>(sqlQuantidadeColaboradores);

            return new RetornoColaboradorPaginado<Colaborador>
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = quantidadeColaboradores,
                Colaboradores = empresas.ToList()
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            string sql = @"
            SELECT C.*,E.NOME AS NomeDaEmpresa
            FROM COLABORADORES C
            INNER JOIN EMPRESAS E
            ON C.EMPRESAID = E.EMPRESAID
            ";
            var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
            return colaboradores.ToList();
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            string sql = $"DELETE FROM COLABORADORES WHERE COLABORADORID={id}";
            var colaboradorDeletado = await _conn.ExecuteAsync(sql);
            return colaboradorDeletado > 0 ? true : false;
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = "INSERT INTO COLABORADORES VALUES (@NOME,@CPF,@MATRICULA,@EMPRESAID)";
            var parametros = new
            {
                NOME = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                EMPRESAID = colaborador.EmpresaID
            };
            var colaboradorInserido = await _conn.ExecuteAsync(sql, parametros);
            return colaboradorInserido > 0 ? true : false;
        }
        catch (Exception e) { throw; }
    }
}
