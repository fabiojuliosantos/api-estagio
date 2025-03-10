using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IVendasService
    {

        Task<RelatorioVendaDto> RelatorioVendas(int id);
        RespostaDTO VenderProduto(int produtoId, int quantidadeVendida);

        RespostaDTO ConsultaEstoque(int produtoId);

    }
}
