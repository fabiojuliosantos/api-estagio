using AutoMapper;
using FluentValidation;
using RH.API.Domain.Entities;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ProdutoService : IProdutoService
{
    private static readonly List<Produto> _produtos = [];
    private readonly IMapper _mapper;

    public ProdutoService(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region CRUD
    public async Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
             where TInputModel : class
             where TOutputModel : class
             where TValidator : AbstractValidator<Produto>
    {
        try
        {
            var entity = _mapper.Map<Produto>(inputModel);

            Validacao<TValidator>(entity);

            if (_produtos.Count == 0)
                entity.Id = 1;
            else
                entity.Id = _produtos.Last().Id + 1; // incrementa o útimo id inserido na lista

            _produtos.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }


    public async Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
              where TInputModel : class
              where TOutputModel : class
              where TValidator : AbstractValidator<Produto>
    {
        try
        {
            var entity = _mapper.Map<Produto>(inputModel);

            //se não existir um id igual ao que será atualizado
            if (!_produtos.Any(f => f.Id == entity.Id))
                throw new Exception("Id não encontrado");

            //validação
            Validacao<TValidator>(entity);

            // Encontrar o índice do produto com ID igual ao enviado
            int index = _produtos.FindIndex(p => p.Id == entity.Id);

            if (index != -1)
                _produtos[index] = entity; // Substitui o Produto antigo pelo novo
            else
                throw new Exception("Produto não encontrado!");

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }

    public async Task<Produto> ListarAsync(int id)
    {
        try
        {
            var Produto = _produtos.FirstOrDefault(f => f.Id == id);

            // valida 
            if (Produto is null)
                throw new Exception("Produto não encontrado!");

            return Produto;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Produto>> ListarAsync()
    {
        try
        {
            if (_produtos.Count == 0)
                throw new Exception("Nenhum Produto encontrado.");
            else
                return _produtos;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Excluir(int id)
    {
        try
        {
            var Produto = _produtos.FirstOrDefault(f => f.Id == id);

            // valida se existe Produto
            if (Produto is null)
                throw new Exception("Produto não encontrado!");

            // remove Produto com id enviado
            _produtos.RemoveAll(p => p.Id == id);
            return true;
        }
        catch (Exception) { throw; }
    }
    #endregion

    private static void Validacao<TValidator>(Produto entity) where TValidator : AbstractValidator<Produto>
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
