using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class CreateEstudanteDto
{
    // Validar se o nome não é vazio, a idade é um número válido e maior que 0, e a matrícula é única. 
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome precisa ter mais de cinco caracteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A idade é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "A idade deve ser maior que zero")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "O curso é obrigatório")]
    [MinLength(5, ErrorMessage = "O curso precisa ter mais de cinco caracteres")]
    public string? Curso { get; set; }
}