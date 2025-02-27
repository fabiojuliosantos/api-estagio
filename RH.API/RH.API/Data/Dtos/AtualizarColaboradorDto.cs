namespace RH.API.Data.Dtos
{
    public class AtualizarColaboradorDto
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Cpf { get; set; } 
        public int Matricula { get; set; }
        public int EmpresaId { get; set; } 
    }
}
