using Dapper;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using System.Data;

namespace RH.API.Infra.Repositories
{
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

                string sql = "UPDATE COLABORADORES SET NOME=@NOME WHERE COLABORADORID=@ID";
                var parametros = new
                {
                    NOME = colaborador.Nome,
                    ID = colaborador.ColaboradorID
                };
                var empresaAtualizada = await _conn.ExecuteAsync(sql, parametros);

                return empresaAtualizada > 0 ? true : false;


            }
            catch (Exception) { throw; }
        }

        public async Task<Colaborador> BuscarColaboradorId(int id)
        {
            try
            {
                string sql = @"
        SELECT c.COLABORADORID, c.NOME, c.CPF, c.MATRICULA, c.EMPRESAID,
               e.EMPRESAID as EmpresaID, e.NOME as Nome 
        FROM COLABORADORES c
        INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
        WHERE c.COLABORADORID = @Id";

                var resultado = await _conn.QueryAsync<Colaborador, Empresa, Colaborador>(
                    sql,
                    (colaborador, empresa) =>
                    {
                        colaborador.Empresa = empresa; 
                        return colaborador;
                    },
                    new { Id = id },
                    splitOn: "EmpresaID" 
                );

                return resultado.FirstOrDefault(); 
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar colaborador por ID {id}: {ex.Message}");
            }
        }

        public async Task<List<Colaborador>> BuscarTodosColaborador()
        {
            try
            {
                string sql = @"
        SELECT c.COLABORADORID, c.NOME, c.CPF, c.MATRICULA, c.EMPRESAID,
               e.EMPRESAID as EmpresaID, e.NOME as Nome 
        FROM COLABORADORES c
        INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID";

                var colaboradores = await _conn.QueryAsync<Colaborador, Empresa, Colaborador>(
                    sql,
                    (colaborador, empresa) =>
                    {
                        colaborador.Empresa = empresa;
                        return colaborador;
                    },
                    splitOn: "EmpresaID" 
                );

                return colaboradores.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os colaboradores: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            try
            {

                string sql = string.Format("DELETE FROM COLABORADORES WHERE COLABORADORID={0}", id);

                var colaboradorExcluida = await _conn.ExecuteAsync(sql);

                return colaboradorExcluida > 0 ? true : false;



            }
            catch (Exception) { throw; }
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = $"INSERT INTO COLABORADORES VALUES(@COLABORADORNOME, @COLABORADORCPF, @COLABORADORMATRICULA,@COLABORADOREMPRESAID)";

                //string sql = string.Format("INSERT INTO EMPRESAS VALUES('{0}')", empresa.Nome);

                var parametros = new
                {
                    COLABORADORNOME = colaborador.Nome,
                    COLABORADORCPF = colaborador.Cpf,
                    COLABORADORMATRICULA = colaborador.Matricula,
                    COLABORADOREMPRESAID = colaborador.EmpresaID
                };

                var colaboradorInserido = await _conn.ExecuteAsync(sql, parametros);

                return colaboradorInserido > 0 ? true : false;



            }
            catch (Exception) { throw; }
        }
        public async Task<Colaborador> BuscarMatricula(int matricula)
        {
            try
            {
                string sql = $"SELECT  * FROM COLABORADORES WHERE MATRICULA=@Matricula";
                var matriculaColaborador = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql, new { Matricula = matricula });
                return matriculaColaborador;



            }
            catch (Exception) { throw; }
        }
    }
}






