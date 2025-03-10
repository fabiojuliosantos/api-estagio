using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class EstudanteService : IEstudanteService
{
    private List<Estudante> _listaEstudante { get; set; } = [];
    public Estudante AdicionarEstudante(CreateEstudanteDto estudanteDto)
    {
        try
        {
            Estudante estudanteCriado = new(estudanteDto.Nome, estudanteDto.Idade, estudanteDto.Curso);
            _listaEstudante.Add(estudanteCriado);
            return estudanteCriado;
           
        }
        catch (Exception) { throw; }
    }

    public Estudante AtualizarMatriculaEstudante(UpdateEstudanteDto estudanteDto)
    {
        try
        {
            int index = _listaEstudante.FindIndex(p => p.Matricula == estudanteDto.Matricula);

            Estudante estudante = _listaEstudante[index] ?? throw new CustomerException("Estudante não foi encontrado");

            estudante.Nome = estudanteDto.Nome ?? estudante.Nome;
            estudante.Idade = estudanteDto.Idade.HasValue && estudanteDto.Idade > 0 ? estudanteDto.Idade.Value : estudante.Idade;
            estudante.Curso = estudanteDto.Curso ?? estudante.Curso;

            _listaEstudante[index] = estudante;

            return estudante;

        }
        catch (Exception) { throw; }
    }

    public List<Estudante> ListarEstudante()
    {
        try
        {
            return [.. _listaEstudante];
        }
        catch (Exception) { throw; }
    }
}