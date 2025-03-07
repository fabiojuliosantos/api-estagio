namespace RH.API.Domain;

public class Livro
{
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public int CodigoBarras { get; set; }
    public bool Disponibilidade { get; set; }

}
