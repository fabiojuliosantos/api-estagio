using RH.API.Domain.Entities;

namespace RH.API.Infra.Interfaces;

public interface IEmpresaRepository
{
    Task<RetornoPaginadoEmp<Empresa>> BuscarEmpresasPorPagina(int pagina, int qtdRegistros);
    Task<List<Empresa>> BuscarTodasEmpresas(); // Task para identificar que é um método assíncrono
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> ExcluirEmpresa(int id);
}
