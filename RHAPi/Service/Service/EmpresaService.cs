using RHAPi.Domain;
using RHAPi.Infra.Interfaces;
using RHAPi.Service.Interfaces;
using RHAPI.Domain;

namespace RHAPi.Service.Service;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;

    public EmpresaService(IEmpresaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            return await _repository.BuscarTodasEmpresas();
        }
        catch (Exception) { throw; }
    }
    public async Task<Empresa> BuscarEmpresaPorID(int id)
    {
        try
        {
            return await _repository.BuscarEmpresaPorID(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try
        {
            return await _repository.InserirEmpresa(empresa);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizarEmpresa(Empresa empresa)
    {
        try
        {
            return await _repository.AtualizarEmpresa(empresa);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeletarEmpresa(int id)
    {
        try
        {
            return await _repository.DeletarEmpresa(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginado<Empresa>> BuscarEmpresaPorPagina(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarEmpresaPorPagina(pagina, quantidade);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}