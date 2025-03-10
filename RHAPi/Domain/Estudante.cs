namespace RHAPI.Domain;

public class Estudante
{
    public Estudante(string? nome, int idade, string? curso)
    {
        Nome = nome;
        Idade = idade;
        Curso = curso;
        Matricula = GerarMatricula();
    }

    // Nome, Idade, Curso e Matrícula.
    public int _contador = 1;
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? Curso { get; set; }
    public string? Matricula { get; set; }

    private string GerarMatricula()
    {
        return $"MAT-{_contador++.ToString("D4")}";
    }
}