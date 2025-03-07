namespace RH.API.Domain;

public class Venda
{
    public int Id { get; set; }
    public Produto ProdutoVendido { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotal{ get; set; }
    public DateTime DataVenda { get; set; }
}
