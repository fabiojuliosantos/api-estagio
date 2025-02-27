using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos;

public class CreateColaboradorDto
{
    [Required(ErrorMessage = "O nome do colaborador é obrigatório!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF do colaborador é obrigatório!")]
    [StringLength(11, MinimumLength=11, ErrorMessage = "O CPF precisa ter 11 caracteres!")]
    public string Cpf { get; set; }
    [Required(ErrorMessage = "A matrícula é obrigatória!")]
    public int Matricula { get; set; }
    [Required(ErrorMessage = "É necessário viincular um colaborador a uma empresa!")]
    public int EmpresaID { get; set; }
}
