using RHAPi.Domain;

namespace RHAPI.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<List<Colaborador>> BuscarTodos();
    Task<Colaborador> BuscarPorId(int id);
    Task<bool> Inserir(Colaborador colaborador);
    Task<bool> Atualizar(Colaborador colaborador);
    Task<bool> Deletar(int id);
}