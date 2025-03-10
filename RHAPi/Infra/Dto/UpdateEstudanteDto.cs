using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class UpdateEstudanteDto
{
    [Required(ErrorMessage = "Matrícula é obrigatório")]
    public string? Matricula { get; set; }

    [MinLength(5, ErrorMessage = "O nome precisa ter mais de cinco caracteres")]
    public string? Nome { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A idade deve ser maior que zero")]
    public int? Idade { get; set; }

    [MinLength(5, ErrorMessage = "O nome precisa ter mais de cinco caracteres")]
    public string? Curso { get; set; }
}