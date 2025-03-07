namespace Biblioteca.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string CodigoBarras { get; set; }
        public bool Disponivel { get; set; } = true; //coloquei true como padrao
    }
}