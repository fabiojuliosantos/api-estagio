namespace RHAPi.Domain;

public class Colaborador
{
    public int ColaboradorID { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Matricula { get; set; }

    public int EmpresaID { get; set; }
}