namespace RH.API.Dto
{
    public class ProdutoGetDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
}
