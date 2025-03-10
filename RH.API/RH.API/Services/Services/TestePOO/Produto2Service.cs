using AutoMapper;
using FluentValidation;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class Produto2Service : IProduto2Service
{
    private static readonly List<Produto2> _produtos = [];
    private static readonly List<Venda> _vendas = [];
    private readonly IMapper _mapper;

    public Produto2Service(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Task<TOutputModel> Cadastrar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Produto2>
    {
        try
        {
            var entity = _mapper.Map<Produto2>(inputModel);

            Validacao<TValidator>(entity);

            // Definindo o id do produto
            if (_produtos.Count == 0)
                entity.Id = 1;
            else
                entity.Id = _produtos.Last().Id + 1; // incrementa o útimo id inserido na lista

            _produtos.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return Task.FromResult(outputModel);
        }
        catch (Exception) { throw; }
    }

    public Task<List<Produto2>> ConsultarEstoque()
    {
        try
        {
            if (_produtos.Count == 0)
                throw new Exception("Nenhum produto foi encontrado!");
            else
                return Task.FromResult(_produtos);
        }
        catch (Exception) { throw; }
    }

    public Task<List<Venda>> RelatorioVendas()
    {
        try
        {
            if (_vendas.Count == 0)
                throw new Exception("Nenhuma venda foi encontrada!");
            else
                return Task.FromResult(_vendas);
        }
        catch (Exception) { throw; }
    }

    public Task<bool> Vender(int id, int quantidade)
    {
        try
        {
            if (!_produtos.Any(p => p.Id == id))
            {
                throw new Exception("O produto não está registrado!");
            }

            Produto2 produto = _produtos.FirstOrDefault(p => p.Id == id);

            if (produto.QtdEstoque >= quantidade)
            {
                produto.QtdEstoque -= quantidade;

                Venda venda = new()
                {
                    idProduto = produto.Id,
                    NomeProduto = produto.Nome,
                    PrecoUnitario = produto.Preco,
                    QtdVendida = quantidade
                };

                _vendas.Add(venda);

                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("A quantidade em estoque não corresponde a quantidade desejada para venda!");
            }
        }
        catch (Exception) { throw; }
    }

    private static void Validacao<TValidator>(Produto2 entity) where TValidator : AbstractValidator<Produto2>
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
