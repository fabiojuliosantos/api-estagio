using System.Data;
using Dapper;
using RH.API.Domain;
using RH.API.Dto;
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
            string sql = @"
            SELECT c.ColaboradorID, c.Nome, c.Cpf, c.Matricula, 
                   e.EmpresaID, e.Nome
            FROM COLABORADORES c
            LEFT JOIN EMPRESAS e ON c.EmpresaID = e.EmpresaID
            WHERE c.ColaboradorID = @Id";

            var colaborador = await _connection.QueryAsync<Colaborador, Empresa, Colaborador>(
                sql,
                (colab, emp) =>
                {
                    colab.Empresa = emp;
                    return colab;
                },
                new { Id = id },
                splitOn: "EmpresaID"
            );

            return colaborador.FirstOrDefault();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<RetornoColaborador<ColaboradorGetDto>> BuscarColaboradoresPorPagina(int pagina, int quantidade)
    {
        try
        {
            string sql = @"
            SELECT 
                c.ColaboradorID, 
                c.Nome, 
                c.CPF, 
                c.MATRICULA, 
                c.EmpresaID, 
                e.Nome
            FROM 
                COLABORADORES c
            INNER JOIN 
                EMPRESAS e ON c.EmpresaID = e.EmpresaID 
            ORDER BY 
                c.ColaboradorID 
            OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade
            };

         
            var colaboradores = await _connection.QueryAsync<ColaboradorGetDto, EmpresaDto, ColaboradorGetDto>(
                sql,
                (colaborador, empresa) =>
                {
                    colaborador.Empresa = empresa;  
                    return colaborador;
                },
                parametros,
                splitOn: "EmpresaID" 
            );

            var totalColaboradores = "SELECT COUNT(*) FROM COLABORADORES";
            var retornoTotalColaboradores = await _connection.ExecuteScalarAsync<int>(totalColaboradores);

            return new RetornoColaborador<ColaboradorGetDto>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = retornoTotalColaboradores,
                Colaboradores = colaboradores.ToList()
            };
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
            SELECT c.ColaboradorID, c.Nome, c.Cpf, c.Matricula, 
                   e.EmpresaID, e.Nome
            FROM COLABORADORES c
            LEFT JOIN EMPRESAS e ON c.EmpresaID = e.EmpresaID";

            var colaboradores = await _connection.QueryAsync<Colaborador, Empresa, Colaborador>(
                sql,
                (colab, emp) =>
                {
                    colab.Empresa = emp;
                    return colab;
                },
                splitOn: "EmpresaID"
            );

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