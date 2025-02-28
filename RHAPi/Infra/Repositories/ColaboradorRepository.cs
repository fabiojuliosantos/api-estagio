using System.Data;
using Dapper;
using RHAPi.Domain;
using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Infra.Interfaces;
using RHAPI.Utils;

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
            string sql = @"
            SELECT TOP 1 
                C.*, 
                E.NOME AS NomeEmpresa 
            FROM 
                COLABORADORES C 
            INNER JOIN 
                EMPRESAS E ON C.EmpresaID = E.EmpresaID 
            WHERE 
                C.ColaboradorID = @ColaboradorId";

            var parametros = new
            {
                ColaboradorId = id
            };
                
            var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql, parametros);

            return colaborador!;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodos()
    {
        try 
        {
            string sql = @"
            SELECT
                C.*, 
                E.NOME AS NomeEmpresa 
            FROM 
                COLABORADORES C 
            INNER JOIN 
                EMPRESAS E ON C.EmpresaID = E.EmpresaID";

            var colaboradores = await _conn.QueryAsync<Colaborador>(sql);

            return colaboradores.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Inserir(CreateColaboradorDto colaborador)
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

    public async Task<RetornoPaginado<Colaborador>> BuscaColaboradorPorPagina(int pagina, int quantidade)
    {
        string sql = @"
            SELECT
                C.*, 
                E.NOME AS NomeEmpresa 
            FROM 
                COLABORADORES C 
            INNER JOIN 
                EMPRESAS E ON C.EmpresaID = E.EmpresaID
            ORDER BY COLABORADORID
            OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

        var parametros = new
        {
            OFFSET = (pagina -1) * quantidade,
            QUANTIDADE = quantidade,
        };

        var colaboradores = await _conn.QueryAsync<Colaborador>(sql, parametros);
        var consultaTotalColaboradores = "SELECT COUNT(*) FROM COLABORADORES";
        var retornoTotalColaboradores = await _conn.ExecuteScalarAsync<int>(consultaTotalColaboradores);
    
        return new RetornoPaginado<Colaborador>()
        {
            Pagina = pagina,
            QtdPagina = quantidade,
            TotalRegistros = retornoTotalColaboradores,
            EmpresasLista = [.. colaboradores],
        };
    }
}