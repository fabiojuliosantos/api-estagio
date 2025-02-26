using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using System.Data;

namespace RH.API.Infra.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly IDbConnection _conn;

    public ColaboradorRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<bool> AtualizarColaboradorAsync(Colaborador colaborador)
    {
        try
        {
            string sql = ("UPDATE COLABORADORES SET NOME=@NOME, CPF=@CPF, MATRICULA=@MATRICULA, EMPRESAID=@EMPRESAID WHERE COLABORADORID=@COLABORADORID");

            var parametros = new
            {
                NOME = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                EMPRESAID = colaborador.EmpresaID,
                COLABORADORID = colaborador.ColaboradorID
            };

            var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

            return colaboradorAtualizado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Colaborador> BuscarColaboradorPorIdAsync(int id)
    {
        try
        {
            string sql = string.Format("SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORID={0}", id);

            var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);

            return colaborador;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradoresAsync()
    {
        try
        {
            string sql = string.Format("SELECT * FROM COLABORADORES");

            var colaboradores = await _conn.QueryAsync<Colaborador>(sql);

            return colaboradores.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExcluirColaboradorAsync(int id)
    {
        try
        {
            string sql = string.Format("DELETE FROM COLABORADORES WHERE COLABORADORID={0}", id);

            var colaborador = await _conn.ExecuteAsync(sql);

            return colaborador > 0;

        }
        catch (Exception) 
        { 
            throw; 
        }
    }

    public async Task<bool> InserirColaboradorAsync(Colaborador colaborador)
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
                COLABORADORID = colaborador.ColaboradorID
            };

            var colaboradorInserido = await _conn.ExecuteAsync(sql, parametros);

            return colaboradorInserido > 0;
        }
        catch (Exception) 
        { 
            throw; 
        }
    }
}
