using rh.api.Domain;

namespace rh.api.Services.Interface;

public interface IEmpresaService
{
    Task<RetornoPaginadoEmpresa<Empresa>> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> ExcluirEmpresa(int id);
}
