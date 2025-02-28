using RH.API.Domain;
using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IColaboradorService
{
    Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade);
    Task<List<ColaboradorDTO>> BuscarTodosColaboradores();
    Task<ColaboradorDTO> BuscarColaboradorPorId(int id);
    Task<bool> InserirColaborador(CreateColaboradorDTO colaboradorDTO);
    Task<bool> AtualizarColaborador(UpdateColaboradorDTO colaboradorDTO);
    Task<bool> ExcluirColaborador(int id);
}
