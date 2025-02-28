using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Infra.Respositories;

public class ColaboradorRepository : IColaboradorRepository
{
    // Conexão com o banco de dados
    private readonly IDbConnection _conn;

    // O construtor recebe uma conexão com o banco e a armazena para uso nos métodos
    public ColaboradorRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            string sql = "UPDATE COLABORADORES SET NOME=@Nome WHERE ID_COLABORADORES=@ID";

            var parametros = new
            {
                Nome = colaborador.Nome,
                ID = colaborador.ColaboradorID,
                MATRICULA = colaborador.Matricula
            };

            // Executa a query de atualização no banco de dados
            var colaboradorAtualizado = await _conn.ExecuteAsync(sql, parametros);

            return colaboradorAtualizado > 0;
        }
        catch (Exception) { throw; }
    }
    public async Task<ColaboradorDTO> BuscarColaboradorPorId(int id)
    {
        try
        {
            string sql = @"
            SELECT c.*, e.Nome AS NomeEmpresa
            FROM COLABORADORES c
            INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID
            WHERE c.ID_COLABORADORES = @Id";

            var parametros = new { Id = id };

            // Executa a consulta retornando um único registro ou null se não encontrado
            var colaborador = await _conn.QueryFirstOrDefaultAsync<ColaboradorDTO>(sql, parametros);

            // Retorna o colaborador encontrado ou null
            return colaborador;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            string sql = @"SELECT ID_COLABORADORES AS ColaboradorID, Nome, CPF, Matricula, EmpresaID 
                        FROM COLABORADORES 
                        ORDER BY ID_COLABORADORES 
                        OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade
            };

            var colaboradores = (await _conn.QueryAsync<Colaborador>(sql, parametros)).ToList();

            var totalColaboradores = "SELECT COUNT(*) FROM COLABORADORES";
            var retornoTotalColaboradores = await _conn.ExecuteScalarAsync<int>(totalColaboradores);

            // Validação: se não houver colaboradores, retorna mensagem de erro
            if (!colaboradores.Any())
            {
                throw new Exception("Nenhum registro encontrado para esta página.");
            }

            return new RetornoPaginadoColaborador<Colaborador>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = retornoTotalColaboradores,
                Colaboradores = colaboradores
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ColaboradorDTO>> BuscarTodosColaboradores()
    {
        try
        {
            string sql = @"
            SELECT c.*, e.Nome AS NomeEmpresa
            FROM COLABORADORES c
            INNER JOIN EMPRESAS e ON c.EMPRESAID = e.EMPRESAID";

            // Executa a consulta retornando uma lista de colaboradores
            var colaboradores = await _conn.QueryAsync<ColaboradorDTO>(sql);
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
            string sql = "DELETE FROM COLABORADORES WHERE ID_COLABORADORES = @ID";

            var parametros = new { ID = id };
            // Executa a query de exclusão
            var colaboradorExcluido = await _conn.ExecuteAsync(sql, parametros);
            // Retorna true se ao menos uma linha foi afetada, indicando sucesso na exclusão
            return colaboradorExcluido > 0;
        }
        catch (Exception) { throw; }
    }
    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            string sqlMaxId = "SELECT ISNULL(MAX(ID_COLABORADORES), 0) FROM COLABORADORES";
            int novoId = await _conn.QueryFirstOrDefaultAsync<int>(sqlMaxId);
            novoId++; // Incrementar o ID

            // Query SQL para inserir um novo colaborador com ID manualmente gerado
            string sql = @"
            INSERT INTO COLABORADORES (ID_COLABORADORES, NOME, CPF, EMPRESAID, MATRICULA) 
            VALUES (@Id, @Nome, @CPF, @EmpresaID, @Matricula)";

            var parametros = new
            {
                Id = novoId,
                Nome = colaborador.Nome,
                CPF = colaborador.CPF,
                EmpresaID = colaborador.EmpresaID,
                Matricula = colaborador.Matricula
            };

            // Executa a query de inserção
            var colaboradorCadastrado = await _conn.ExecuteAsync(sql, parametros);

            // Retorna true se ao menos uma linha foi afetada, indicando sucesso na inserção
            return colaboradorCadastrado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}