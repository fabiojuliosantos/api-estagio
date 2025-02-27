using RHAPi.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<List<Colaborador>> BuscarTodos();
    Task<Colaborador> BuscarPorId(int id);
    Task<bool> Inserir(CreateColaboradorDto colaborador);
    Task<bool> Atualizar(Colaborador colaborador);
    Task<bool> Deletar(int id);
}