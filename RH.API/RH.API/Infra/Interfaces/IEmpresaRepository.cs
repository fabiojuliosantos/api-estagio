using RH.API.Domain;

namespace RH.API.Infra.Interfaces;

public interface IEmpresaRepository
{
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorIdAsync(int id);
    Task<bool> InserirEmpresaAsync(Empresa empresa);
    Task<bool> AtualizarEmpresaAsync(Empresa empresa);
    Task<bool> ExcluirEmpresaAsync(int id);
}
