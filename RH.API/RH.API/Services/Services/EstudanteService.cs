using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstudanteService : IEstudanteService
{
    private static int _proximoId = 1;
    private List<Estudante> _estudantes = new();
    private readonly IMapper _mapper;

    public EstudanteService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public RespostaDTO AdicionarEstudante(AdicionarEstudanteDto estudanteDto)
    {
        try
        {
            if (String.IsNullOrEmpty(estudanteDto.Nome))
            {
                return new RespostaDTO(false, "Nome não pode ser nulo");
            }
            if (estudanteDto.Idade <= 0 || estudanteDto.Idade >= 100)
            {
                return new RespostaDTO(false, "Insira uma idade válida para o estudante");
            }
            if (String.IsNullOrEmpty(estudanteDto.Curso))
            {
                return new RespostaDTO(false, "O curso não pode ser nulo");
            }

            var estudante = _mapper.Map<Estudante>(estudanteDto);

            estudante.Matricula = _proximoId++;

            _estudantes.Add(estudante);
            return new RespostaDTO(true, "Estudante cadastrado com sucesso!!");
       


        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO AtualizarMatriculaEstudante(int matricula,Estudante estudante)
    {
        try
        {
            if(String.IsNullOrEmpty(estudante.Nome))
            {
                return new RespostaDTO(false, "Nome não pode ser nulo");
            }
            if (estudante.Idade <= 0 || estudante.Idade >= 100)
            {
                return new RespostaDTO(false, "Insira uma idade válida para o estudante");
            }
            if (String.IsNullOrEmpty(estudante.Curso))
            {
                return new RespostaDTO(false, "O curso não pode ser nulo");
            }
            if(estudante.Matricula < 0)
            {
                return new RespostaDTO(false, "Matricula não pode ser negativa");
            }
            var estudanteExistente = _estudantes.FirstOrDefault(p => p.Matricula == estudante.Matricula);

            if (estudanteExistente == null)
            {
                return new RespostaDTO(false, "Nenhum estudantte foi encontrado");

            }

            estudanteExistente.Nome = estudante.Nome;
            estudanteExistente.Curso = estudante.Curso;
            estudanteExistente.Idade = estudante.Idade;
            estudanteExistente.Matricula = estudante.Matricula;

            return new RespostaDTO(true, "Estudante atualizado com sucesso");

        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Estudante> ExibirEstudantes()
    {
        try
        {
            if (!_estudantes.Any())
            {
               throw new Exception("Nenhum estudante foi encontrado");
            }

            foreach(var estudantes in _estudantes)
            {
                Console.WriteLine($"Matrícula: {estudantes.Matricula}\nNome: {estudantes.Nome}\nCurso: {estudantes.Curso}\nIdade: {estudantes.Idade}");
            }
            return _estudantes;
        }
        catch (Exception ex)
        {

            throw new Exception("Ocorreu um erro ao processar a lista de estudantes. Detalhes: " + ex.Message);
        }
    }
}
