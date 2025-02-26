using rh.api.Domain;
using rh.api.Infra.Interfaces;
using rh.api.Services.Interface;

namespace rh.api.Services.Services;

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
        catch (Exception) 
        { 
            throw; 
        }
    }

    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try 
        {
            return await _repository.BuscarEmpresaPorId(id);
        } 
        catch (Exception) 
        {
            throw; 
        }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            var empresas = await _repository.BuscarTodasEmpresas();

            return empresas;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExcluirEmpresa(int id)
    {
        try 
        {
            return await _repository.ExcluirEmpresa(id);
        } 
        catch (Exception) 
        { 
            throw; 
        }
    }

    public async Task<bool> InserirEmpresa(Empresa empresa)
    {
        try 
        {
            return await _repository.InserirEmpresa(empresa);
        } 
        catch (Exception) 
        { 
            throw; 
        }
    }
}
