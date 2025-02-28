using RH.API.Domain;

namespace RH.API.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<RetornoPaginadoCol<Colaborador>> BuscarColaboradoresPorPagina(int pagina, int qtdRegistros);
    Task<bool> CpfExistenteAsync(string cpf);
    Task<List<Colaborador>> BuscarTodosColaboradores(); // Task para identificar que é um método assíncrono
    Task<Colaborador> BuscarColaboradorPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> ExcluirColaborador(int id);
}
