namespace RH.API.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
    }
    public class CreateFuncionarioDTO
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
    }
}
