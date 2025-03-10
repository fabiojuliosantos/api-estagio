using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto;

public class CreateVendaDto
{
    [Required(ErrorMessage ="Digite o id do produto!")]
    [Range(1,int.MaxValue, ErrorMessage ="O id do produto é inválido!.")]
    public int IdProduto { get; set; }
    [Required(ErrorMessage ="Digite a quantidade de produtos para a venda!")]
    [Range(0,int.MaxValue, ErrorMessage ="Quantidade inválida!")]
    public int Quantidade { get; set; }
}
