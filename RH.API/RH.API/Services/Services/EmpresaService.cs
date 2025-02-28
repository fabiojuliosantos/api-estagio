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
    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            var empresas = await _repository.BuscarTodasEmpresas();

            return empresas;
        }
        catch (Exception) { throw; }
    }
    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try
        {
            return await _repository.BuscarEmpresaPorId(id);
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
    public async Task<bool> ExcluirEmpresa(int id)
    {
        try
        {
            return await _repository.ExcluirEmpresa(id);
        }
        catch (Exception) { throw; }
    }

    public async Task<RetornoPaginado<Empresa>> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarEmpresasPorPagina(pagina, quantidade); 
        }
        catch (Exception) { throw; }
    }
}
