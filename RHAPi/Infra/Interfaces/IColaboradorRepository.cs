using RHAPi.Domain;
using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Infra.Interfaces;

public interface IColaboradorRepository
{
    Task<RetornoPaginado<Colaborador>> BuscaColaboradorPorPagina(int pagina, int quantidade);
    Task<List<Colaborador>> BuscarTodos();
    Task<Colaborador> BuscarPorId(int id);
    Task<bool> Inserir(CreateColaboradorDto colaborador);
    Task<bool> Atualizar(Colaborador colaborador);
    Task<bool> Deletar(int id);
}