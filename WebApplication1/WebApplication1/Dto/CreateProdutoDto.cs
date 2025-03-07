using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class CreateProdutoDto
{
    [Required(ErrorMessage ="Digite o nome do produto!")]
    [MaxLength(100, ErrorMessage ="O nome pode possuir no máximo 100 caracteres!")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Digite o preço do produto!")]
    [Range(1,double.MaxValue, ErrorMessage = "Digite um preço válido para o produto!")]
    public double Preco { get; set; }
    [Required(ErrorMessage = "Digite a quantidade do produto!")]
    [Range(0, int.MaxValue, ErrorMessage = "Digite uma quantidade válida!")]
    public int QuantidadeEmEstoque { get; set; }
}
