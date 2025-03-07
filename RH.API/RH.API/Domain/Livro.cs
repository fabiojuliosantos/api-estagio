namespace RH.API.Domain;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public string CodigoBarras { get; set; }
    public bool Emprestado { get; set; }
}
