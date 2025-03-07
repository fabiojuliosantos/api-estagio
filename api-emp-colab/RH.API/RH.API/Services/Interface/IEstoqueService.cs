using RH.API.Domain;

public interface IEstoqueService
{
    (bool Sucesso, string Mensagem) AdicionarProduto(Produto produto);
    List<Produto> ListarProdutos();
    (bool Sucesso, string Mensagem) VenderProduto(string produtoNome, int quantidade);
    Produto ConsultarEstoque(string produtoNome);
    List<Venda> GerarRelatorioVendas();
}
