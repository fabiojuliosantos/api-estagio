using RHAPi.Domain;
using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;
public interface IColaboradorService
{
    Task<RetornoPaginado<Colaborador>> BuscarColaboradorPorPagina(int pagina, int quantidade);
    Task<List<Colaborador>> BucarTodosColaboradores();
    Task<Colaborador> BucarColaboradorPorId(int id);
    Task<bool> InserirColaborador(CreateColaboradorDto colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> DeletarColaborador(int id);
}