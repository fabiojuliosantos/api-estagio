using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos.TestePOO;

public class CreateEstudanteDto
{
    [Required(ErrorMessage = "O nome do estudante é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A idade do estudante é obrigatória!")]

    public int Idade { get; set; }

    [Required(ErrorMessage = "O curso do estudante é obrigatório!")]

    public string Curso { get; set; }


    [Required(ErrorMessage = "A matrícula do estudante é obrigatória!")]
    public int Matricula { get; set; }
}
