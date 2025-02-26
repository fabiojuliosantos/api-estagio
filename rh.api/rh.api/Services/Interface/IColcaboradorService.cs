using rh.api.Domain;

namespace rh.api.Services.Interface
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> BuscarTodosColaboradoresAsync();
        Task<Colaborador> BuscarColaboradorPorId(int id);
        Task<bool> InserirColaborador(Colaborador colaborador);
        Task<bool> AtualizarColaborador(Colaborador colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
