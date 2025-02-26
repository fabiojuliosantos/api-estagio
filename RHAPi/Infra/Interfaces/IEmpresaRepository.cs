using RHAPi.Domain;

namespace RHAPi.Infra.Interfaces;
public interface IEmpresaRepository
{
    Task<List<Empresa>> BuscarTodasEmpresas();
    Task<Empresa> BuscarEmpresaPorID(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> DeletarEmpresa(int id);

}