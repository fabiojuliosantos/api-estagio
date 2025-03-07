using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstudanteService : IEstudanteService
{
    List<Estudante> estudantes = new List<Estudante>();
    public Estudante AdicionarEstudante(Estudante estudante)
    {
        try
        {
            if (estudante == null)
            {
                throw new Exception("Estudante inválido!");
            }
            else if (estudantes.Find(e => e.Matricula == estudante.Matricula) != null)
            {
                throw new Exception($"O estudante com matrícula {estudante.Matricula} já existe!");
            }
            else
            {
                estudantes.Add(estudante);
                return estudante;
            }
        }
        catch (Exception e) { throw e; }
    }

    public Estudante AtualizarEstudante(Estudante estudante)
    {
        try
        {
            if (estudante == null)
            {
                throw new Exception("Estudante inválido!");
            }
            else if (estudantes.Find(e => e.Matricula == estudante.Matricula) == null)
            {
                throw new Exception($"O estudante com matrícula {estudante.Matricula} não existe!");
            }
            else
            {
                var estudanteParaAtualizar = estudantes.Find(e => e.Matricula == estudante.Matricula);
                estudanteParaAtualizar.Nome = estudante.Nome;
                estudanteParaAtualizar.Idade = estudante.Idade;
                estudanteParaAtualizar.Curso = estudante.Curso;
                return estudante;
            }
        }
        catch (Exception e) { throw e; }
    }

    public List<Estudante> ListarEstudantes()
    {
        try
        {
            return estudantes;
        }
        catch (Exception e) { throw e; }
    }
}
