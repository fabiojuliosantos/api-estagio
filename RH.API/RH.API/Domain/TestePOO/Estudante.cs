namespace RH.API.Domain.TestePOO;

public class Estudante
{
    public Estudante(string nome, int idade, string curso, int matricula)
    {
        Nome = nome;
        Idade = idade;
        Curso = curso;
        Matricula = matricula;
    }

    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Curso { get; set; }
    public int Matricula { get; set; }
}
