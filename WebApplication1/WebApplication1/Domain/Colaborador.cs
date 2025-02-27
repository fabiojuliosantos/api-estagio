namespace RH.API.Domain;

public class Colaborador
{
    public int ColaboradorID { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Matricula {  get; set; }
    public int EmpresaID { get; set; }

    public string NomeDaEmpresa { get; set; }
}
