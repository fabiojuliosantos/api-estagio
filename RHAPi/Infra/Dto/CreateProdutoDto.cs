using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "Nome do produto é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome do produto deve ter mais de cinc caracteres.")]
    public string? NomeProduto { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório")]
    [Range(1, double.MaxValue, ErrorMessage = "O Preço do produto deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "É necessario adicionar um item ao cadastrar um produto")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade do produto deve ser maior que zero")]
    public int QuantidaEstoque { get; set; }
}