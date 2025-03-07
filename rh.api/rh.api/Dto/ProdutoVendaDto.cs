namespace rh.api.Dto
{
    public class ProdutoVendaDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }

    public class VendaRequest
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }

    public class VendaResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }

    
}