using System.Reflection.Metadata.Ecma335;

namespace RH.API.Domain.Entities.TestePOO;

public class Funcionario
{
    public Funcionario()
    {

    }

    public Funcionario(string nome, string cargo, string salario)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
    }

    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Salario { get; set; }
}
