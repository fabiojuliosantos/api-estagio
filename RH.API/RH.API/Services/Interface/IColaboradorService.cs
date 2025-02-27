using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IColaboradorService
    {
        Task<List<Colaborador>> BuscarTodosColaborador();
        Task<Colaborador> BuscarColaboradorId(int id);
        Task<RespostaDTO> InserirColaborador(InserirColaboradorDto colaboradorDto);
        Task<RespostaDTO> AtualizarColaborador(AtualizarColaboradorDto colaboradorDto);
        Task<RespostaDTO> ExcluirColaborador(int id);
    }
}
