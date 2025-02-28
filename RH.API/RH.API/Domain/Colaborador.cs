using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH.API.Domain;

public class Colaborador
{
    [Key]
    [Column("ID_COLABORADORES")]
    public int ColaboradorID { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Matricula { get; set; }
    public int EmpresaID { get; set; }
}
