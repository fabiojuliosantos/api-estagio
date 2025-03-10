namespace RHAPI.Domain;

public class Venda
{
    private static int _codigoVendaCounter = 0;
    
    public Venda(Produto produto, int quantidade, decimal valorTotal)
    {
        Produto = produto;
        Quantidade = quantidade;
        ValorTotal = valorTotal;
        
        _codigoVendaCounter++;
        CodigoVenda = $"VENDA_{_codigoVendaCounter:D4}";
    }

    public string CodigoVenda { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
}