using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class CreateBcomDto
{
    [Required(ErrorMessage = "Digite o titular da conta!")]
    [StringLength(100,ErrorMessage = "O nome não pode possuir mais de 100 caracteres")]
    public string Titular { get; set; }
    [Required(ErrorMessage = "Digite o número da conta!")]
    [Range(1,int.MaxValue,ErrorMessage = "Número da conta inválido!")]
    public int NumeroDaConta { get; set; }
    [Required(ErrorMessage = "Digite o saldo da conta!")]
    [Range(0, double.MaxValue, ErrorMessage = "Saldo inválido!")]
    public double Saldo { get; set; }
}
