using RH.API.Domain;

namespace RH.API.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<List<Colaborador>> BuscarTodosColaboradoresAsync();
    Task<Colaborador> BuscarColaboradorPorIdAsync(int id);
    Task<bool> InserirColaboradorAsync(Colaborador colaborador);
    Task<bool> AtualizarColaboradorAsync(Colaborador colaborador);
    Task<bool> ExcluirColaboradorAsync(int id);
}
