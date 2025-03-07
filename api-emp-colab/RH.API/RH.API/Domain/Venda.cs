namespace RH.API.Domain
{
    public class Venda
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
