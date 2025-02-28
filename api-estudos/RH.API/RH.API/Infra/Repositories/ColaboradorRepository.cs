using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories;

public class ColaboradorRepository : IColaboradorRepository
{
    private readonly IDbConnection _connection;

    public ColaboradorRepository(IDbConnection connection)
    {
        _connection = connection;
    }



    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            string sql = @"SELECT c.ColaboradorID, c.Nome, c.Cpf, c.Matricula, c.EmpresaID, e.Nome AS EmpresaNome
                       FROM COLABORADORES c
                       LEFT JOIN EMPRESAS e ON c.EmpresaID = e.EmpresaID
                       WHERE c.ColaboradorID = @Id";

            var colaborador = await _connection.QueryFirstOrDefaultAsync<Colaborador>(sql, new { Id = id });
            return colaborador;
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
            string sql = @"SELECT c.ColaboradorID, c.Nome, c.Cpf, c.Matricula, c.EmpresaID, e.Nome AS EmpresaNome
                       FROM COLABORADORES c
                       LEFT JOIN EMPRESAS e ON c.EmpresaID = e.EmpresaID";

            var colaboradores = await _connection.QueryAsync<Colaborador>(sql);
            return colaboradores.ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = @"INSERT INTO COLABORADORES (Nome, Cpf, Matricula, EmpresaID) 
                       VALUES (@Nome, @Cpf, @Matricula, @EmpresaID)";

            var parametros = new
            {
                Nome = colaborador.Nome,
                Cpf = colaborador.Cpf,
                Matricula = colaborador.Matricula,
                EmpresaID = colaborador.EmpresaID
            };

            var colaboradorCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return colaboradorCadastrado > 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = @"UPDATE COLABORADORES 
                       SET Nome = @Nome, 
                           Cpf = @Cpf, 
                           Matricula = @Matricula, 
                           EmpresaID = @EmpresaID
                       WHERE ColaboradorID = @ColaboradorID";

            var parametros = new
            {
                Nome = colaborador.Nome,
                Cpf = colaborador.Cpf,
                Matricula = colaborador.Matricula,
                EmpresaID = colaborador.EmpresaID,
            };

            var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);

            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }



    public async Task<bool> ExcluirColaborador(int colaboradorID)
    {
        try
        {
            string sql = @"DELETE FROM COLABORADORES WHERE ColaboradorID = @ColaboradorID";

            var parametros = new { ColaboradorID = colaboradorID };

            var linhasAfetadas = await _connection.ExecuteAsync(sql, parametros);

            return linhasAfetadas > 0;
        }
        catch (Exception ex)
        {
            throw;
        }
    }




}