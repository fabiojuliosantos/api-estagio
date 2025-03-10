namespace RH.API.Data.Dtos.TestePOO;

public class LivroDTO
{
    public int CodigoBarras { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public bool Disponibilidade { get; set; }
}

public class CreateLivroDTO
{
    public int CodigoBarras { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public bool Disponibilidade { get; set; }
}
