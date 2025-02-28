using RH.API.Domain;
using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IColaboradorRepository
{
    Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade);
    Task<List<ColaboradorDTO>> BuscarTodosColaboradores();
    Task<ColaboradorDTO> BuscarColaboradorPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> ExcluirColaborador(int id);
}
