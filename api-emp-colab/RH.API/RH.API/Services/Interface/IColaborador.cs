using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Services.Interface
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> BuscarTodosColaboradores();
        Task<Colaborador> BuscarColaboradoresPorId(int id);
        Task<bool> InserirColaborador(CreateColaboradorDto colaborador);
        Task<bool> AtualizarColaborador(int id, UpdateColaboradorDto colaborador);
        Task<bool> ExcluirColaborador(int id);
    }
}
