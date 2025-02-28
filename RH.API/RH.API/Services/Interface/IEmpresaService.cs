using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IEmpresaService
{
    Task<RetornoPaginado<Empresa>> BuscarEmpresaPorPagina(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresasAsync();
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<RespostaDTO> InserirEmpresa(EmpresaDto empresaDto);
    Task<RespostaDTO> AtualizarEmpresa( AtualizarEmpresaDto empresaDto);
    Task<RespostaDTO> ExcluirEmpresa(int id);
}
