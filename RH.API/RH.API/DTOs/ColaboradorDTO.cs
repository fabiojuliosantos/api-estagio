using System.ComponentModel.DataAnnotations;

namespace RH.API.DTOs;

public class ColaboradorDTO
{
    [StringLength(100, ErrorMessage = "Nome não pode ter mais que 100 caracteres.")]
    public string? Nome { get; set; }

    [StringLength(11, ErrorMessage = "CPF deve ter exatamente 11 caracteres.")]
    public string? CPF { get; set; }
    public int Matricula { get; set; }
    public int EmpresaID { get; set; }
    public string NomeEmpresa { get; set; }
}