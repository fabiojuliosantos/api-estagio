using RH.API.Dto;

public interface IEstoqueService
{
    (bool Sucesso, string Mensagem, EstoqueGetDto Produto) AdicionarProduto(EstoqueDto estoqueDto);
    (bool Sucesso, string Mensagem) AtualizarProduto(int id, EstoqueUpdateDto estoqueUpdateDto);
    (bool Sucesso, string Mensagem, IEnumerable<EstoqueGetDto> Produtos) ObterProdutos();
    (bool Sucesso, string Mensagem, EstoqueGetDto Produto) ConsultarEstoque(int produtoId);
    (bool Sucesso, string Mensagem) VenderProduto(int produtoId, int quantidade);
    IEnumerable<RelatorioVendaDto> GerarRelatorioVendas(); 
}
