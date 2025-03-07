using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<RetornoColaborador<ColaboradorGetDto>> BuscarColaboradoresPorPagina(int pagina, int quantidade);
    Task<List<Colaborador>> BuscarTodosColaboradores();
    Task<Colaborador> BuscarColaboradorPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> ExcluirColaborador(int id);
}