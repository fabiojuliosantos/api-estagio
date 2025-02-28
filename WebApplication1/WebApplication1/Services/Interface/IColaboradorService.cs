using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IColaboradorService
{
    Task<RetornoColaboradorPaginado<Colaborador>> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade);
    Task<List<Colaborador>> BuscarTodosColaboradoresAsync();
    Task<Colaborador> BuscarColaboradoresPorIdAsync(int id);
    Task<bool> InserirColaboradorAsync(Colaborador colaborador);
    Task<bool> AtualizarColaboradorAsync(Colaborador colaborador);
    Task<bool> ExcluirColaboradorAsync(int id);
}
