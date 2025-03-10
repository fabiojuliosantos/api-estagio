namespace RH.API.Data.Dtos
{
    public class RelatorioVendaDto
    {
        public int IdVenda { get; set; }
        public DateTime HoraVenda { get; set; }
        public string NomeProduto { get; set; }
        public double ValorTotal { get; set; }
        public int QuantidadeVendida { get; set; }
    }
}