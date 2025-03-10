using FluentValidation;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface IProduto2Service
{
    Task<TOutputModel> Cadastrar<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class // restrição para que só aceite classe
        where TOutputModel : class
        where TValidator : AbstractValidator<Produto2>; 
    Task<bool> Vender(int id, int quantidade);
    Task<List<Produto2>> ConsultarEstoque();
    Task<List<Venda>> RelatorioVendas();
}
