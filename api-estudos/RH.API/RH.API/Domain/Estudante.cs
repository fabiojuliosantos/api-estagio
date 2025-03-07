using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RH.API.Domain
{
    public class Estudante
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A idade é obrigatória.")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "A matrícula é obrigatória.")]
        public int Matricula { get; set; }
    }
}
