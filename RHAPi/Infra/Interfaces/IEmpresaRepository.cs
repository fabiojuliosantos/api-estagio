using RHAPi.Domain;
using RHAPI.Domain;

namespace RHAPi.Infra.Interfaces;
public interface IEmpresaRepository
{
    Task<RetornoPaginado<Empresa>> BuscarEmpresaPorPagina(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresas();
    Task<Empresa> BuscarEmpresaPorID(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> DeletarEmpresa(int id);

}