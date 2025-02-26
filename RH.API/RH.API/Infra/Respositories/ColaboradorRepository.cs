using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Infra.Respositories;

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
            string sql = "UPDATE COLABORADOR SET NOME=@NOME WHERE COLABORADORES=@ID";
            var parametros = new
            {
                COLABORADORES = colaborador.Nome,
                ID = colaborador.EmpresaID
            };
            var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

            return colaboradorAtualizado > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORES={id}";
            var colaboradores = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
            return colaboradores;
        }
        catch (Exception) { throw; }
    }
    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            string sql = "SELECT * FROM COLABORADORES";
            var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
            return colaboradores.ToList();
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            string sql = string.Format("DELETE FROM COLABORADOR WHERE COLABORADOR={0}", id);

            var colaboradorExcluido = await _conn.ExecuteAsync(sql);

            return colaboradorExcluido > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = $"INSERT INTO COLABORADORES VALUES(@COLABORADORES)";

            var parametros = new
            {
                COLABORADORES = colaborador.Nome
            };
            var colaboradorCadastrada = await _conn.ExecuteAsync(sql, parametros);

            return colaboradorCadastrada > 0 ? true : false;
        }
        catch (Exception) { throw; }
    }
}
