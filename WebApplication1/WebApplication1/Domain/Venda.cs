namespace RH.API.Domain;

public class Venda
{
    public int Id { get; set; }
    public int IdProduto { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotal { get; set; }
}