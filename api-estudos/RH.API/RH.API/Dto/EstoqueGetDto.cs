namespace RH.API.Dto
{
    public class EstoqueGetDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QtdEstoque { get; set; }
    }
}
