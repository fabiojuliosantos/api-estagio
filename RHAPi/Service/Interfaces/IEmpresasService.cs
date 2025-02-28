using RHAPi.Domain;
using RHAPI.Domain;

namespace RHAPi.Service.Interfaces;

public interface IEmpresaService
{
    Task<RetornoPaginado<Empresa>> BuscarEmpresaPorPagina(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorID(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> DeletarEmpresa(int id);
}