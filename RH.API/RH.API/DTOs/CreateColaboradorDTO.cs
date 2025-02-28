using System.ComponentModel.DataAnnotations;

namespace RH.API.DTOs;

public class CreateColaboradorDTO
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "Nome não pode ter mais que 100 caracteres.")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    public required string CPF { get; set; }

    [Required(ErrorMessage = "Matrícula é obrigatória.")]
    public int Matricula { get; set; }

    [Required(ErrorMessage = "Empresa é obrigatória.")]
    public int EmpresaID { get; set; }
}
