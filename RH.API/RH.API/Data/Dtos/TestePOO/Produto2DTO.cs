namespace RH.API.Data.Dtos.TestePOO;

public class Produto2DTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int QtdEstoque { get; set; }
}

public class CreateProduto2DTO
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int QtdEstoque { get; set; }
}
