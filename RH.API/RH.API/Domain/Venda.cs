namespace RH.API.Domain;

public class Venda
{
    public int IdVenda { get; set; }
    public DateTime HoraVenda { get; set; }
    public double ValorTotal { get; set; }
    public int ProdutoId { get; set; }
    public int QuantidadeVendida { get; set; }
}
