using rh.api.Domain;

namespace rh.api.Infra.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int quantidade);
        Task<List<Colaborador>> BuscarTodosColaboradores();
        Task<Colaborador> BuscarColaboradorPorId(int id);
        Task<bool> InserirColaborador(Colaborador colaborador);
        Task<bool> AtualizarColaborador(Colaborador colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
