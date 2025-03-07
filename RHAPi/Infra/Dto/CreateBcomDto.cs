using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class CreateBcomDto
{

    [Required(ErrorMessage = "O titular é obrigatório.")]
    public string? Titular { get; set; }
    [Required(ErrorMessage = "O saldo é obrigatóro.")]
    [Range(1, double.MaxValue, ErrorMessage = "O saldo deve ser positivo e maior ou igaul a 1.")]
    public decimal Saldo { get; set; }
}