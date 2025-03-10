namespace RH.API.Domain;

public class Venda
{
    public int IdVenda { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotal { get; set; }
    public string NomeDoProduto { get; set; }
}