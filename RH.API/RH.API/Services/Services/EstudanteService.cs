using AutoMapper;
using FluentValidation;
using RH.API.Domain.Entities;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstudanteService : IEstudanteService
{
    private static readonly List<Estudante> _estudantes = [];
    private readonly IMapper _mapper;

    public EstudanteService(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region CRUD
    public async Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
             where TInputModel : class
             where TOutputModel : class
             where TValidator : AbstractValidator<Estudante>
    {
        try
        {
            var entity = _mapper.Map<Estudante>(inputModel);

            Validacao<TValidator>(entity);

            if (_estudantes.Count == 0)
                entity.Matricula = 1;
            else
                entity.Matricula = _estudantes.Last().Matricula + 1; // incrementa o útimo id inserido na lista

            _estudantes.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }


    public async Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
              where TInputModel : class
              where TOutputModel : class
              where TValidator : AbstractValidator<Estudante>
    {
        try
        {
            var entity = _mapper.Map<Estudante>(inputModel);

            //se não existir um id igual ao que será atualizado
            if (!_estudantes.Any(f => f.Matricula == entity.Matricula))
                throw new Exception("Id não encontrado");

            //validação
            Validacao<TValidator>(entity);

            // Encontrar o índice do Estudante com ID igual ao enviado
            int index = _estudantes.FindIndex(p => p.Matricula == entity.Matricula);

            if (index != -1)
                _estudantes[index] = entity; // Substitui o Estudante antigo pelo novo
            else
                throw new Exception("Estudante não encontrado!");

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }

    public async Task<Estudante> ListarAsync(int matricula)
    {
        try
        {
            var Estudante = _estudantes.FirstOrDefault(f => f.Matricula == matricula);

            // valida 
            if (Estudante is null)
                throw new Exception("Estudante não encontrado!");

            return Estudante;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Estudante>> ListarAsync()
    {
        try
        {
            if (_estudantes.Count == 0)
                throw new Exception("Nenhum Estudante encontrado.");
            else
                return _estudantes;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Excluir(int matricula)
    {
        try
        {
            var Estudante = _estudantes.FirstOrDefault(f => f.Matricula == matricula);

            // valida se existe Estudante
            if (Estudante is null)
                throw new Exception("Estudante não encontrado!");

            // remove Estudante com id enviado
            _estudantes.RemoveAll(p => p.Matricula == matricula);
            return true;
        }
        catch (Exception) { throw; }
    }
    #endregion

    private static void Validacao<TValidator>(Estudante entity) where TValidator : AbstractValidator<Estudante>
    {
        try
        {
            var validator = Activator.CreateInstance<TValidator>();
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(error => new string(error.ErrorMessage));
                var errorString = string.Join(Environment.NewLine, errors);

                throw new Exception(errorString);
            }
        }
        catch (Exception) { throw; }
    }
}
