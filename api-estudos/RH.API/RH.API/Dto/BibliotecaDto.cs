using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto
{
    public class BibliotecaDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O autor é obrigatório.")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O ano de publicação é obrigatório.")]
        public int AnoPublicacao { get; set; }
        [Required(ErrorMessage = "O código de barras é obrigatório.")]
        public int CodigoDeBarras { get; set; }

    }
}
