﻿// REGRAS DE NEGOCIO

using System.Data;
using Dapper;
using RH.API.Domain.Entities;
using RH.API.Infra.Interfaces;

namespace RH.API.Infra.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IDbConnection _connection;

    public EmpresaRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<RetornoPaginadoEmp<Empresa>> BuscarEmpresasPorPagina(int pagina, int quantidade)
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS ORDER BY EMPRESAID OFFSET @OFFSET ROWS FETCH NEXT @QUANTIDADE ROWS ONLY";

            var parametros = new
            {
                OFFSET = (pagina - 1) * quantidade,
                QUANTIDADE = quantidade,
            };

            var empresas = await _connection.QueryAsync<Empresa>(sql, parametros);

            var totalEmpresas = "SELECT COUNT(*) FROM EMPRESAS";

            var retornoTotalEmpresas = await _connection.ExecuteScalarAsync<int>(totalEmpresas);

            return new RetornoPaginadoEmp<Empresa>()
            {
                Pagina = pagina,
                QtdPagina = quantidade,
                TotalRegistros = retornoTotalEmpresas,
                Empresas = empresas.ToList()
            };
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            string sql = "UPDATE EMPRESAS SET NOME=@NOME WHERE EMPRESAID=@ID";
            var parametros = new
            {
                NOME = empresa.Nome,
                ID = empresa.EmpresaID
            };

            var empresaAtualizada = await _connection.ExecuteAsync(sql, parametros);

            return empresaAtualizada > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            string sql = $"SELECT TOP 1 * FROM EMPRESAS WHERE EMPRESAID={id}";
            var empresa = await _connection.QueryFirstOrDefaultAsync<Empresa>(sql);
            return empresa;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresas()
    {
        try
        {
            string sql = "SELECT * FROM EMPRESAS";
            var empresas = await _connection.QueryAsync<Empresa>(sql);

            //await _connection.QueryFirstOrDefaultAsync<Empresa>(sql); // Retorna top 1

            return empresas.ToList(); // Retornando o resultado como uma lista
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            // Fazendo pelo metodo de string format
            string sql = string.Format("DELETE FROM EMPRESAS WHERE EMPRESAID={0}", id);

            var empresaExcluida = await _connection.ExecuteAsync(sql);

            return empresaExcluida > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try
        {
            string sql = $"INSERT INTO EMPRESAS VALUES (@EMPRESA)"; //Passando como parametro uma variável escalar (espera a definição de um parametro)

            // string sql = string.Format("INSERT INTO EMPRESAS VALUES('{0}')", empresa.Nome); // Passar dessa maneira quando houver erro e jogar a query formatada no banco para teste

            var parametros = new
            {
                EMPRESA = empresa.Nome
            };
            var empresaCadastrada = await _connection.ExecuteAsync(sql, parametros);

            return empresaCadastrada > 0 ? true : false;
        }
        catch (Exception ex) { throw; }
    }
}
