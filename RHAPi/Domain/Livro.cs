namespace RHAPI.Domain;

public class Livro
{
    public Livro(string? titulo, string? autor, int anoPublicacao, string? codigoBarras, bool disponivel)
    {
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        CodigoBarras = codigoBarras;
        Disponivel = disponivel;
    }

    // informando o título, autor, ano de publicação e código de barras único. 
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public string? CodigoBarras { get; set; }

    public bool Disponivel { get; set; }

    

}