// VALIDAÇÕES

using System.Linq.Expressions;
using RH.API.Domain.Entities;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;

    public EmpresaService(IEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            return await _repository.AtualizarEmpresa(empresa);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            return await _repository.BuscarEmpresaPorId(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<RetornoPaginadoEmp<Empresa>> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarEmpresasPorPagina(pagina, quantidade);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            var empresas = await _repository.BuscarTodasEmpresas();

            return empresas;
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            return await _repository.ExcluirEmpresa(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try
        {
            return await _repository.InserirEmpresa(empresa);
        }
        catch (Exception ex) { throw; }
    }
}
