namespace RH.API.Domain.TestePOO;

public class Produto
{
    public Produto(int id, string nome, double preco, int qtdEstoque)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        QtdEstoque = qtdEstoque;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int QtdEstoque { get; set; }
}
