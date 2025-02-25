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
            return await _repository.AtualizarEmpresa(empresa);
        }
        catch (Exception e) { throw; }
    }

    public async Task<Empresa> BuscarEmpresaPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscarEmpresaPorId(id);
        }
        catch (Exception e) { throw; }
    }

    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            return await _repository.BuscarTodasEmpresas();
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> ExcluirEmpresaAsync(int id)
    {
        try 
        { 
            return await _repository.ExcluirEmpresa(id);
        }
        catch (Exception e) { throw; }
    }

    public async Task<bool> InserirEmpresaAsync(Empresa empresa)
    {
        try 
        { 
            return await _repository.InserirEmpresa(empresa);                     
        }
        catch (Exception e) { throw; }
    }
}
