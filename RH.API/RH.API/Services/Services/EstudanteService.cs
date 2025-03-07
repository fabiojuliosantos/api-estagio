using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstudanteService : IEstudanteService
{
    private static List<Estudante> _estudantes = new();
    private static int _proximoId = 1;

    public EstudanteDTO AdicionarEstudante(EstudanteDTO estudanteDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(estudanteDTO.Nome))
            {
                throw new Exception("O nome do estudante é obrigatorio");
            }
            if (estudanteDTO.Idade <= 0)
            {
                throw new Exception("A idade deve ser maior que zero e numero inteiro");
            }
            if (_estudantes.Any(e => e.Matricula == estudanteDTO.Matricula))
            {
                throw new Exception("ja existe um estudante com essa matricula");
            }

            var novoEstudante = new Estudante
            {
                Id = _proximoId,
                Nome = estudanteDTO.Nome,
                Idade = estudanteDTO.Idade,
                Curso = estudanteDTO.Curso,
                Matricula = estudanteDTO.Matricula
            };

            _estudantes.Add(novoEstudante);

            return new EstudanteDTO
            {
                Nome = novoEstudante.Nome,
                Idade = novoEstudante.Idade,
                Curso = novoEstudante.Curso,
                Matricula = novoEstudante.Matricula
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool AtualizarMatricula(string matriculaAntiga, string matriculaNova)
    {
        try
        {
            var estudante = _estudantes.FirstOrDefault(e => e.Matricula == matriculaAntiga);
            if (estudante == null)
            {
                return false;
            }
            if (_estudantes.Any(e => e.Matricula == matriculaNova))
            {
                throw new Exception("ja existe um estudante com essa matricula");
            }
            estudante.Matricula = matriculaNova;
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public EstudanteDTO BuscarEstudantePorMatricula(string matricula)
    {
        try
        {
            var estudante = _estudantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudante == null)
            {
                return null;
            }
            return new EstudanteDTO
            {
                Nome = estudante.Nome,
                Idade = estudante.Idade,
                Curso = estudante.Curso,
                Matricula = estudante.Matricula
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<EstudanteDTO> ListarEstudantes()
    {
        try
        {
            return _estudantes.Select(e => new EstudanteDTO
            {
                Nome = e.Nome,
                Idade = e.Idade,
                Curso = e.Curso,
                Matricula = e.Matricula
            });
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool RemoverEstudante(string matricula)
    {
        try
        {
            var estudante = _estudantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudante == null)
            {
                return false;
            }
            return _estudantes.Remove(estudante);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
