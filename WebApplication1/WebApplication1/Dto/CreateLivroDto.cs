using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class CreateLivroDto
{
    [Required(ErrorMessage ="Digite o título do livro!")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Digite o autor do livro!")]
    public string Autor { get; set; }
    [Required(ErrorMessage = "Digite o ano de publicação do livro!")]
    [Range(1,2025,ErrorMessage ="Ano inválido!")]
    public int AnoDePublicacao { get; set; }
    [Required(ErrorMessage = "Digite o código de barras do livro!")]
    [Range(1,int.MaxValue,ErrorMessage ="Código de Barras inválido!")]
    public int CodigoDeBarras { get; set; }
}
