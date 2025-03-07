using AutoMapper;
using FluentValidation;
using RH.API.Domain.Entities;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class FuncionarioService : IFuncionarioService
{
    private static readonly List<Funcionario> _funcionarios = [];
    private readonly IMapper _mapper;

    public FuncionarioService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
             where TInputModel : class
             where TOutputModel : class
             where TValidator : AbstractValidator<Funcionario>
    {
        try
        {
            var entity = _mapper.Map<Funcionario>(inputModel);

            Validacao<TValidator>(entity);

            if (_funcionarios.Count == 0)
                entity.Id = 1;
            else
                entity.Id = _funcionarios.Last().Id + 1; // incrementa o útimo id inserido na lista

            _funcionarios.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }


    public async Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
              where TInputModel : class
              where TOutputModel : class
              where TValidator : AbstractValidator<Funcionario>
    {
        try
        {
            var entity = _mapper.Map<Funcionario>(inputModel);

            //se não existir um id igual ao que será atualizado
            if (!_funcionarios.Any(f => f.Id == entity.Id))
                throw new Exception("Id não encontrao");

            //validação
            Validacao<TValidator>(entity);

            // Encontrar o índice do produto com ID igual ao enviado
            int index = _funcionarios.FindIndex(p => p.Id == entity.Id);

            if (index != -1)
                _funcionarios[index] = entity; // Substitui o funcionario antigo pelo novo
            else
                throw new Exception("Funcionário não encontrado!");

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }

    public async Task<Funcionario> ListarAsync(int id)
    {
        try
        {
            var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
            
            // valida 
            if (funcionario is null)
                throw new Exception("Funcionário não encontrado!");

            return funcionario;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Funcionario>> ListarAsync()
    {
        try
        {
            if (_funcionarios.Count == 0)
                throw new Exception("Nenhum funcionário encontrado.");
            else
                return _funcionarios;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Excluir(int id)
    {
        try
        {
            var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
            
            // valida se existe funcionário
            if (funcionario is null)
                throw new Exception("Funcionário não encontrado!");

            // remove funcionario com id enviado
            _funcionarios.RemoveAll(p => p.Id == id);
            return true;
        }
        catch (Exception) { throw; }
    }

    private static void Validacao<TValidator>(Funcionario entity) where TValidator : AbstractValidator<Funcionario>
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
