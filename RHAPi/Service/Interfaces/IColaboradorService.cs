using RHAPi.Domain;

namespace RHAPI.Service.Interfaces;
public interface IColaboradorService
{
    Task<List<Colaborador>> BucarTodosColaboradores();
    Task<Colaborador> BucarColaboradorPorId(int id);
    Task<bool> InserirColaborador(Colaborador colaborador);
    Task<bool> AtualizarColaborador(Colaborador colaborador);
    Task<bool> DeletarColaborador(int id);
}