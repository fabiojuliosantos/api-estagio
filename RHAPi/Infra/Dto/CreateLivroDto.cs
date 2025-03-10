using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class CreateLivroDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O Autor é obrigatório.")]
    public string? Autor { get; set; }

    [Required(ErrorMessage = "O Ano de publicação é obrigatório.")]
    public int AnoPublicacao { get; set; }

    [Required(ErrorMessage = "O Codigo de barras é obrigatório.")]
    public string? CodigoBarras { get; set; }

}