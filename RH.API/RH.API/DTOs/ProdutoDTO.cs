namespace RH.API.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
    public class CreateProdutoDTO
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
}
