namespace RH.API.Domain;

public class Colaborador
{
    public Colaborador()
    {
        
    }
    public Colaborador(string nome, string cpf, int matricula, int empresaID, string nomeEmpresa)
    {
        Nome = nome;
        Cpf = cpf;
        Matricula = matricula;
        EmpresaID = empresaID;
        NomeEmpresa = nomeEmpresa;
    }

    public int ColaboradorID { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Matricula { get; set; }
    public int EmpresaID { get; set; }
    public string NomeEmpresa { get; set; }
}
