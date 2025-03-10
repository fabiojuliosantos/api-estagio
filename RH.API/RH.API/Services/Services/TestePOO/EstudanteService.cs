using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class EstudanteService : IEstudanteService
{
    private readonly List<Estudante> _estudantes = [];
    public Task<bool> AtualizarMatricula(Estudante estudante)
    {
        try
        {
            Estudante matriculaAntiga = _estudantes.FirstOrDefault(e => e.Matricula == estudante.Matricula);

            if (matriculaAntiga == null) throw new Exception("Matrícula não registrada!");

            if (estudante.Nome == null) throw new Exception("O nome não pode ser nulo!");

            if (estudante.Idade <= 0 || estudante.Idade > 150) throw new Exception("Idade inserida inválida!");

            if (estudante.Curso == null) throw new Exception("O curso não pode ser nulo!");

            else
            {
                // Obtém o índice do estudante encontrado na lista
                int index = _estudantes.IndexOf(matriculaAntiga);

                // Substitui o estudante antigo pelo novo
                _estudantes[index] = estudante;

                return Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<List<Estudante>> BuscarTodosEstudantes()
    {
        try
        {
            if (_estudantes.Count() == 0)
                throw new Exception("Não há estudantes cadastrados!");
            else
            {
                List<Estudante> estudantes = _estudantes;
                return Task.FromResult(estudantes);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<bool> InserirEstudante(Estudante estudante)
    {
        try
        {
            if (_estudantes.Any(p => p.Matricula == estudante.Matricula)) throw new Exception("A matrícula informada já está registrada!");

            if (estudante.Idade <= 0 || estudante.Idade > 150) throw new Exception("Idade inserida inválida!");

            if(estudante.Matricula <= 0) throw new Exception("Matrícula inserida inválida!");

            else
            {
                _estudantes.Add(estudante);
                return Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
