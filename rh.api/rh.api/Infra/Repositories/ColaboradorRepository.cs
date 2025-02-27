using Dapper;
using rh.api.Domain;
using rh.api.Infra.Interfaces;
using System.Data;

namespace rh.api.Infra.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IDbConnection _conn;

        public ColaboradorRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<Colaborador> BuscarColaboradorPorId(int id)
        {
            try
            {
                
                string sql = "SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORID = @Id";
                var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql, new { Id = id });
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
                string sql = "SELECT * FROM COLABORADORES";
                var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
                return colaboradores.ToList();
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
                    CPF = colaborador.Cpf,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaID
                };

                //ExecuteAsync retorna o número de linhas afetadas
                var colaboradorCadastrado = await _conn.ExecuteAsync(sql, parametros);

                return colaboradorCadastrado > 0; //Se for maior que 0, significa que o colaborador foi inserido
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                
                string sql = "UPDATE COLABORADORES SET NOME = @NOME, CPF = @CPF, MATRICULA = @MATRICULA, IDEMPRESA = @IDEMPRESA WHERE COLABORADORID = @ID";

                var parametros = new
                {
                    ID = colaborador.ColaboradorID, 
                    NOME = colaborador.Nome,
                    CPF = colaborador.Cpf,
                    MATRICULA = colaborador.Matricula,
                    IDEMPRESA = colaborador.EmpresaID
                };

                var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

                return colaboradorAtualizado > 0; //Se for maior que 0, significa que o colaborador foi atualizado
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
                
                string sql = "DELETE FROM COLABORADORES WHERE COLABORADORID = @Id";

                var colaboradorExcluido = await _conn.ExecuteAsync(sql, new { Id = id });

                return colaboradorExcluido > 0; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
