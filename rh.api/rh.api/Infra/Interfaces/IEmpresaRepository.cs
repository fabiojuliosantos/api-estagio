using rh.api.Domain;

namespace rh.api.Infra.Interfaces;

public interface IEmpresaRepository
{
    Task<RetornoPaginadoEmpresa<Empresa>> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresas();
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> ExcluirEmpresa(int id);
}
