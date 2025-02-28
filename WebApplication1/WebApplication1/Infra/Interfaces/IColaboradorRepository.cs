using RH.API.Domain;

namespace RH.API.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<RetornoColaboradorPaginado<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int quantidade);
    Task<List<Colaborador>> BuscarTodosColaboradores();
    Task<Colaborador> BuscarColaboradoresPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> ExcluirColaborador(int id);

}
