using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class UpdateColaboradorDto
{
    [Required(ErrorMessage = "Digite o Id do colaborador.")]
    public int ColaboradorID { get; set; }
    [Required(ErrorMessage = "Digite o nome do colaborador!")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o CPF do colaborador!")]
    [CpfValidation(ErrorMessage = "CPF inválido.")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Digite a matrícula do colaborador!")]
    [Range(1, int.MaxValue, ErrorMessage = "A matrícula deve ser um número positivo.")]
    public int Matricula { get; set; }

    [Required(ErrorMessage = "Digite o ID da empresa!")]
    [Range(1, int.MaxValue, ErrorMessage = "O ID da empresa deve ser um número positivo.")]
    public int EmpresaID { get; set; }
}
