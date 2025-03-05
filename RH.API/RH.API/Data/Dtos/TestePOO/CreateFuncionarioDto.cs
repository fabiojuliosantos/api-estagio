using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos.TestePOO;

public class CreateFuncionarioDto
{
    [Required(ErrorMessage = "O nome do funcionário é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O cargo do funcionário é obrigatório!")]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "O salário do funcionário é obrigatório!")]
    public string Salario { get; set; }
}
