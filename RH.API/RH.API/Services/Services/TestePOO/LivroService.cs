using AutoMapper;
using FluentValidation;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class LivroService : ILivroService
{
    private static readonly List<Livro> _livros = [];
    private readonly IMapper _mapper;

    public LivroService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<TOutputModel> CadastrarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Livro>
    {
        try
        {
            var entity = _mapper.Map<Livro>(inputModel);

            Validacao<TValidator>(entity);
            
            _livros.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return Task.FromResult(outputModel);
        }
        catch (Exception) { throw; } 
    }

    public Task<bool> Devolver(int codigoBarras)
    {
        try
        {
            if (!_livros.Any(l => l.CodigoBarras == codigoBarras))
            {
                throw new Exception("O livro não está registrado!");
            }

            Livro livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);

            if (livro.Disponibilidade == false)
            {
                livro.Disponibilidade = true;
                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("Não é possível devolver um livro que não foi emprestado!");
            }
        }
        catch (Exception) { throw; }
    }

    public Task<bool> Emprestar(int codigoBarras)
    {
        try
        {
            if (!_livros.Any(l => l.CodigoBarras == codigoBarras))
            {
                throw new Exception("O livro não está registrado!");
            }

            Livro livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);

            if (livro.Disponibilidade == true)
            {
                livro.Disponibilidade = false;
                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("Não é possível emprestar um livro que não foi devolvido!");
            }
        }
        catch (Exception) { throw; }
    }

    public Task<List<Livro>> ListarAsync()
    {
        try
        {
            if (_livros.Count == 0)
                throw new Exception("Nenhum livro foi encontrado!");
            else
                return Task.FromResult(_livros);
        }
        catch (Exception) { throw; }
    }

    private static void Validacao<TValidator>(Livro entity) where TValidator : AbstractValidator<Livro>
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
