using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class EstudanteDto
{
    [Required(ErrorMessage = "Digite a matrícula do estudante!")]
    [Range(1, int.MaxValue, ErrorMessage = "Digite uma matrícula válida!")]
    public int Matricula { get; set; }
    [Required(ErrorMessage = "Digite o nome do estudante!")]
    [MaxLength(100, ErrorMessage = "O nome do estudante pode possuir no máximo 100 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digite a idade do estudante!")]
    [Range(1, int.MaxValue, ErrorMessage = "Digite uma idade válida!")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "Digite o curso do estudante!")]
    [MaxLength(100, ErrorMessage = "O curso do estudante pode possuir no máximo 100 caracteres.")]
    public string Curso { get; set; }
}
