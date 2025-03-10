using System;
using System.ComponentModel.DataAnnotations;

namespace RHAPi.Infra.Dto;
public class CreateVendaDto
{
    [Required(ErrorMessage = "O campo CodigoProduto é obrigatório.")]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }
}

