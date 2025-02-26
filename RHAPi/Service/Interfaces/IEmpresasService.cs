using RHAPi.Domain;

namespace RHAPi.Service.Interfaces;

public interface IEmpresaService
{
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorID(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> DeletarEmpresa(int id);
}