using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories
{
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly IDbConnection _connection;

        public ColaboradoresRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = "UPDATE COLABORADORES SET NOME=@NOME, CPF=@CPF, MATRICULA=@MATRICULA, EMPRESAID=@EMPRESAID WHERE COLABORADORID=@ID";
                var parametros = new
                {
                    NOME = colaborador.Nome,
                    CPF = colaborador.CPF,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaId,
                    ID = colaborador.ColaboradorId
                };
                var colaboradorAtualizado = await _connection.ExecuteAsync(sql, parametros);

                return colaboradorAtualizado > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Colaborador> BuscarColaboradoresPorId(int id)
        {
            try
            {
                string sql = @"
            SELECT c.*, e.EMPRESAID, e.NOME AS EmpresaNome
            FROM COLABORADORES c
            INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
            WHERE c.COLABORADORID = @ID";

                var colaborador = await _connection.QueryAsync<Colaborador, Empresa, Colaborador>(
                    sql,
                    (colaborador, empresa) =>
                    {
                        colaborador.Empresa = empresa;
                        return colaborador;
                    },
                    new { ID = id },
                    splitOn: "EMPRESAID"
                );

                return colaborador.FirstOrDefault();
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
            SELECT c.*, e.EMPRESAID, e.NOME AS EmpresaNome
            FROM COLABORADORES c
            INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID";

                var colaboradores = await _connection.QueryAsync<Colaborador, Empresa, Colaborador>(
                    sql,
                    (colaborador, empresa) =>
                    {
                        colaborador.Empresa = empresa;
                        return colaborador;
                    },
                    splitOn: "EMPRESAID"
                );

                return colaboradores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            try
            {
                string sql = "DELETE FROM COLABORADORES WHERE COLABORADORID = @ID";
                var colaboradorExcluido = await _connection.ExecuteAsync(sql, new { ID = id });
                return colaboradorExcluido > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = "INSERT INTO COLABORADORES (NOME, CPF, MATRICULA, EMPRESAID) VALUES (@NOME, @CPF, @MATRICULA, @EMPRESAID)";
                var parametros = new
                {
                    NOME = colaborador.Nome,
                    CPF = colaborador.CPF,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaId
                };
                var colaboradorInserido = await _connection.ExecuteAsync(sql, parametros);
                return colaboradorInserido > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
