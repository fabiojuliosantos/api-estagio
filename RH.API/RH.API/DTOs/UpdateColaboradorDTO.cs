using System.ComponentModel.DataAnnotations;

namespace RH.API.DTOs;

public class UpdateColaboradorDTO
{
    [Required(ErrorMessage = "O ID do colaborador é obrigatório.")]
    public int ColaboradorId { get; set; }

    [StringLength(100, ErrorMessage = "Nome não pode ter mais que 100 caracteres.")]
    public string? Nome { get; set; }
    public int? Matricula { get; set; }
    public int? EmpresaId { get; set; }
}
