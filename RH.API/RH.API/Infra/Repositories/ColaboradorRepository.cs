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

                string sql = "UPDATE COLABORAORES SET NOME=@NOME WHERE COLABORADORID=@ID";
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

        public  async Task<Colaborador> BuscarColaboradorId(int id)
        {
            try
            {
                string sql = $"SELECT TOP 1 * FROM COLABORAORES WHERE COLABORADORID={id}";
                var colaboradorId = await _conn.QueryFirstOrDefaultAsync<Colaborador>(sql);
                return colaboradorId;



            }
            catch (Exception) { throw; }
        }

        public async Task<List<Colaborador>> BuscarTodosColaborador()
        {
            try
            {

                string sql = $"SELECT * FROM COLABORAORES";
                var colaboradores = await _conn.QueryAsync<Colaborador>(sql);
                return colaboradores.ToList();



            }catch (Exception) { throw; }
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            try
            {

                string sql = string.Format("DELETE FROM COLABORAORES WHERE EMPRESAID={0}", id);

                var colaboradorExcluida = await _conn.ExecuteAsync(sql);

                return colaboradorExcluida > 0 ? true : false;



            }
            catch (Exception) { throw; }
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            try
            {
                string sql = $"INSERT INTO COLABORAORES VALUES(@COLABORADORNOME, @COLABORADORCPF, @COLABORADORMATRICULA,@COLABORADOREMPRESAID)";

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
    }
}
