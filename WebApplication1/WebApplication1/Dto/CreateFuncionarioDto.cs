using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class CreateFuncionarioDto
{
    [Required(ErrorMessage = "Digite o nome do funcionário!")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o cargo do funcionário!")]
    [StringLength(100, ErrorMessage = "O cargo não pode ter mais de 100 caracteres.")]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "Digite o salario do funcionário!")]
    [Range(0, double.MaxValue, ErrorMessage = "Digite um salário válido.")]
    public double Salario { get; set; }
}
