namespace RH.API.Domain;

public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoDePublicacao { get; set; }
    public int CodigoDeBarras { get; set; }
    public string Disponibilidade { get; set; }
}
