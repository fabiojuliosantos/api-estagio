using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class CreateColaboradorDto
{
    [Required(ErrorMessage = "Nome do colaborador é obrigatório")]
    [MaxLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    public string? Nome { get; set; }

    [Required]
    [StringLength(11, ErrorMessage = "Cpf deve ter 11 digitos")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "Matrícula do colaborador é obrigatório")]
    public string? Matricula { get; set; }

     [Required(ErrorMessage = "É necessário associar um colaborador a uma empresa")]
    public int EmpresaID { get; set; }
}