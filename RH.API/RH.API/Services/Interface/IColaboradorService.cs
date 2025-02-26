using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IColaboradorService
{
    Task<List<Colaborador>> BuscarTodosColaboradoresAsync();
    Task<Colaborador> BuscarColaboradorPorIdAsync(int id);
    Task<string> InserirColaboradorAsync(Colaborador empresa);
    Task<string> AtualizarColaboradorAsync(Colaborador empresa);
    Task<string> ExcluirColaboradorAsync(int id);
}
