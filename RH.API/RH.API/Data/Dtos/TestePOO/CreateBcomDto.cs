using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos.TestePOO;

public class CreateBcomDto
{
    [Required(ErrorMessage = "O nome do titular é obrigatório!")]
    public string Titular { get; set; }

    [Required(ErrorMessage = "O número da conta é obrigatório!")]
    public int NumeroConta { get; set; }

    [Required(ErrorMessage = "O saldo é obrigatório!")]
    public double Saldo { get; set; }
}
