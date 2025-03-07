namespace RH.API.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
}
