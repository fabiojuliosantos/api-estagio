using System.ComponentModel.DataAnnotations;

namespace RH.API.Data.Dtos;

public class InserirColaboradorDto
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Matricula { get; set; }

    public int EmpresaId { get; set; }
}
