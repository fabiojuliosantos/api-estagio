namespace RH.API.DTOs;

public class LivroDTO
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public string CodigoBarras { get; set; }
    public bool Disponivel { get; set; }
}
