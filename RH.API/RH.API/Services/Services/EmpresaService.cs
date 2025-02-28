using RH.API.Domain;
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

    public async Task<bool> AtualizarEmpresaAsync(Empresa empresa)
    {
        try 
        {
            return await _repository.AtualizarEmpresaAsync(empresa);    
        } 
        catch (Exception) 
        { 
            throw; 
        }
    }

    public async Task<Empresa> BuscarEmpresaPorIdAsync(int id)
    {
        try 
        {
            return await _repository.BuscarEmpresaPorIdAsync(id);
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
            var empresas = await _repository.BuscarTodasEmpresasAsync();

            return empresas;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExcluirEmpresaAsync(int id)
    {
        try 
        {
            return await _repository.ExcluirEmpresaAsync(id);
        } 
        catch (Exception) 
        { 
            throw; 
        }
    }

    public async Task<bool> InserirEmpresaAsync(Empresa empresa)
    {
        try 
        {
            return await _repository.InserirEmpresaAsync(empresa);
        } 
        catch (Exception) 
        { 
            throw; 
        }
    }
}
