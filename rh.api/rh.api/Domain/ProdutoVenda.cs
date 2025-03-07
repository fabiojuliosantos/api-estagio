public class ProdutoVenda
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int QuantidadeVendida { get; set; }
    public DateTime DataVenda { get; set; }
}