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

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = "UPDATE COLABORADORES SET NOME='@NOME' WHERE COLABORADORID=@ID";
            var parametros = new
            {
                NOME = colaborador.Nome,
                ID = colaborador.ColaboradorID
            };

            var colaboradorAtualizado = await _connection.ExecuteAsync(sql, parametros);

            return colaboradorAtualizado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORID={id}";
            var colaborador = await _connection.QueryFirstOrDefaultAsync<Colaborador>(sql);
            return colaborador;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            string sql = "SELECT * FROM COLABORADORES";
            var colaboradores = await _connection.QueryAsync<Colaborador>(sql);

            //await _connection.QueryFirstOrDefaultAsync<Empresa>(sql); // Retorna top 1

            return colaboradores.ToList(); // Retornando o resultado como uma lista
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            // Fazendo pelo metodo de string format
            string sql = string.Format("DELETE FROM COLABORADORES WHERE COLABORADORID={0}", id);

            var colaboradorExcluido = await _connection.ExecuteAsync(sql);

            return colaboradorExcluido > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = $"INSERT INTO COLABORADORES VALUES (@COLABORADOR, @CPF, @MATRICULA, @EMPRESAID)"; //Passando como parametro uma variável escalar (espera a definição de um parametro)

            // string sql = string.Format("INSERT INTO COLABORADORES VALUES('{0}')", colaborador.Nome); // Passar dessa maneira quando houver erro e jogar a query formatada no banco para teste

            var parametros = new
            {
                COLABORADOR = colaborador.Nome,
                CPF = colaborador.Cpf,
                MATRICULA = colaborador.Matricula,
                EMPRESAID = colaborador.EmpresaID
            };
            var colaboradorCadastrado = await _connection.ExecuteAsync(sql, parametros);

            return colaboradorCadastrado > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
