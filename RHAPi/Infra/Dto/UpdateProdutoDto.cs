using System.ComponentModel.DataAnnotations;

namespace RHAPI.Infra.Dto;

public class UpdateProdutoDto
{
    [Required(ErrorMessage = "O id do produto é obrigatório.")]
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = "O nome do produto deve ter mais de cinc caracteres.")]
    public string? NomeProduto { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "O Preço do produto deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A quantidade do produto deve ser maior que zero")]
    public int QuantidaEstoque { get; set; }
}