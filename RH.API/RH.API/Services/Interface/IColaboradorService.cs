using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> BuscarTodosColaborador();
        Task<Colaborador> BuscarColaboradorId(int id);
        Task<bool> InserirColaborador(Colaborador colaborador);
        Task<bool> AtualizarColaborador(Colaborador colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
