using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IColaboradorService
{
    Task<RetornoPaginadoCol<Colaborador>> BuscarColaboradoresPorPaginaAsync(int pagina, int quantidade);
    Task<List<Colaborador>> BuscarTodosColaboradoresAsync();
    Task<Colaborador> BuscarColaboradorPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> ExcluirColaborador(int id);
}
