using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos.TestePOO;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O ID do produto é obrigatório!")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório!")]
    public double Preco { get; set; }

    [Required(ErrorMessage = "A quantidade em estoque do produto é obrigatória!")]
    public int QtdEstoque { get; set; }
}
