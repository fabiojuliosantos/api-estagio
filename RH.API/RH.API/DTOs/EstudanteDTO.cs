namespace RH.API.DTOs
{
    public class EstudanteDTO
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Curso { get; set; }
        public int Matricula { get; set; }
    }
    public class CreateEstudanteDTO
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Curso { get; set; }
    }
}
