//using Dapper;
//using rh.api.Domain;
//using rh.api.Infra.Interfaces;
//using System.Data;

//namespace rh.api.Infra.Repositories
//{
//    public class ColaboradorRepository : IColaboradorRepository
//    {
//        private readonly IDbConnection _conn;

//        public ColaboradorRepository(IDbConnection conn)
//        {
//            _conn = conn;
//        }

//        public async Task<Colaborador> BuscarColaboradorPorId(int id)
//        {
//            try
//            {

//                //string sql = $"SELECT TOP 1 * FROM COLABORADORES WHERE COLABORADORES = {id}";
//                //var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
//                //return colaborador;
//                string sql = @$"
//                     SELECT TOP 1 c.*,c.NOME AS NomeEmpresa
//                     FROM COLABORADORES c
//                     INNER JOIN EMPRESAS c
//                     ON c.EMPRESAID = c.EMPRESAID
//                     WHERE COLABORADORES={id}"
//                var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
//                return colaborador;

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<List<Colaborador>> BuscarTodosColaboradores()
//        {
//            try
//            {
//                string sql = "SELECT * FROM COLABORADORES";
//                var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
//                return colaboradores.ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<bool> InserirColaborador(Colaborador colaborador)
//        {
//            try
//            {

//                string sql = "INSERT INTO COLABORADORES (NOME, CPF, MATRICULA, EMPRESAID) VALUES (@NOME, @CPF, @MATRICULA, @EMPRESAID)";

//                var parametros = new
//                {
//                    NOME = colaborador.Nome,
//                    CPF = colaborador.Cpf,
//                    MATRICULA = colaborador.Matricula,
//                    EMPRESAID = colaborador.EmpresaID
//                };

//                //ExecuteAsync retorna o número de linhas afetadas
//                var colaboradorCadastrado = await _conn.ExecuteAsync(sql, parametros);

//                return colaboradorCadastrado > 0; //Se for maior que 0, significa que o colaborador foi inserido
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
//        {
//            try
//            {

//                string sql = "UPDATE COLABORADORES SET NOME = @NOME, CPF = @CPF, MATRICULA = @MATRICULA, IDEMPRESA = @IDEMPRESA WHERE COLABORADORID = @ID";

//                var parametros = new
//                {
//                    ID = colaborador.ColaboradorID, 
//                    NOME = colaborador.Nome,
//                    CPF = colaborador.Cpf,
//                    MATRICULA = colaborador.Matricula,
//                    IDEMPRESA = colaborador.EmpresaID
//                };

//                var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

//                return colaboradorAtualizado > 0; //Se for maior que 0, significa que o colaborador foi atualizado
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<bool> ExcluirColaborador(int id)
//        {
//            try
//            {

//                string sql = "DELETE FROM COLABORADORES WHERE COLABORADORES = @Id";

//                var colaboradorExcluido = await _conn.ExecuteAsync(sql);

//                return colaboradorExcluido > 0 ? true : false; 
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int quantidade)
//        {
//            try
//            {
//                string sql = @"
//            SELECT c.*, e.NOME AS NomeEmpresa
//            FROM COLABORADORES c
//            INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
//            ORDER BY c.COLABORADORES
//            OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

//                var parametros = new
//                {
//                    OFFSET = (pagina - 1) * quantidade,
//                    QUANTIDADE = quantidade
//                };

//                var colaboradores = await _conn.QueryAsync<Colaborador>(sql, parametros);

//                string qtdDeColaboradorSql = "SELECT COUNT(*) FROM COLABORADORES";
//                var qtdDeColaboradores = await _conn.QueryFirstOrDefaultAsync<int>(qtdDeColaboradorSql);

//                return new RetornoPaginadoColaborador<Colaborador>
//                {
//                    Pagina = pagina,
//                    QtdPagina = quantidade,
//                    TotalRegistros = qtdDeColaboradores,
//                    Colaboradores = colaboradores.ToList()
//                };
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Erro ao buscar colaboradores paginados: {ex.Message}", ex);
//            }
//        }
//    }

//    }

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
                
                string sql = @"
                    SELECT TOP 1 c.*, e.NOME AS NomeEmpresa
                    FROM COLABORADORES c
                    INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
                    WHERE c.COLABORADORID = @Id";

                var colaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql, new { Id = id });
                return colaborador;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar colaborador por ID: {ex.Message}", ex);
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
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os colaboradores: {ex.Message}", ex);
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

                var colaboradorCadastrado = await _conn.ExecuteAsync(sql, parametros);

                return colaboradorCadastrado > 0; //Se for maior que 0, significa que o colaborador foi inserido
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir colaborador: {ex.Message}", ex);
            }
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = "UPDATE COLABORADORES SET NOME = @NOME, CPF = @CPF, MATRICULA = @MATRICULA, EMPRESAID = @EMPRESAID WHERE COLABORADORID = @ID";

                var parametros = new
                {
                    ID = colaborador.ColaboradorID,
                    NOME = colaborador.Nome,
                    CPF = colaborador.Cpf,
                    MATRICULA = colaborador.Matricula,
                    EMPRESAID = colaborador.EmpresaID
                };

                var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

                return colaboradorAtualizado > 0; //Se for maior que 0, significa que o colaborador foi atualizado
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar colaborador: {ex.Message}", ex);
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
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir colaborador: {ex.Message}", ex);
            }
        }

        public async Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int quantidade)
        {
            try
            {
                string sql = @"
                    SELECT c.*, e.NOME AS NomeEmpresa
                    FROM COLABORADORES c
                    INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
                    ORDER BY c.COLABORADORES
                    OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

                var parametros = new
                {
                    OFFSET = (pagina - 1) * quantidade,
                    QUANTIDADE = quantidade
                };

                var colaboradores = await _conn.QueryAsync<Colaborador>(sql, parametros);

                string qtdDeColaboradorSql = "SELECT COUNT(*) FROM COLABORADORES";
                var qtdDeColaboradores = await _conn.QueryFirstOrDefaultAsync<int>(qtdDeColaboradorSql);

                return new RetornoPaginadoColaborador<Colaborador>
                {
                    Pagina = pagina,
                    QtdPagina = quantidade,
                    TotalRegistros = qtdDeColaboradores,
                    Colaboradores = colaboradores.ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar colaboradores paginados: {ex.Message}", ex);
            }
        }
    }
}
