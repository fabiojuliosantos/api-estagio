using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using RH.API.Domain.Entities;
using RH.API.Services.Interface;
using static Dapper.SqlMapper;

namespace RH.API.Services.Services;

public class ContaBancariaService : IContaBancariaService
{
    private static readonly List<ContaBancaria> _contaBancarias = [];
    private readonly IMapper _mapper;

    public ContaBancariaService(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region CRUD
    public async Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
             where TInputModel : class
             where TOutputModel : class
             where TValidator : AbstractValidator<ContaBancaria>
    {
        try
        {
            var entity = _mapper.Map<ContaBancaria>(inputModel);

            Validacao<TValidator>(entity);

            if (_contaBancarias.Any(e => e.NumeroConta == entity.NumeroConta))
                throw new Exception("Numero da Conta já existe.");

            _contaBancarias.Add(entity);

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }


    public async Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
              where TInputModel : class
              where TOutputModel : class
              where TValidator : AbstractValidator<ContaBancaria>
    {
        try
        {
            var entity = _mapper.Map<ContaBancaria>(inputModel);

            //se não existir um contabancaria igual ao que será atualizado
            if (!_contaBancarias.Any(e => e.NumeroConta == entity.NumeroConta))
                throw new Exception("Conta Bancária não encontrada!");

            //validação
            Validacao<TValidator>(entity);

            // Encontrar o índice do produto com NumeroConta igual ao enviado
            int index = _contaBancarias.FindIndex(p => p.NumeroConta == entity.NumeroConta);

            if (index != -1)
                _contaBancarias[index] = entity; // Substitui o ContaBancaria antigo pelo novo
            else
                throw new Exception("Conta Bancária não encontrado!");

            var outputModel = _mapper.Map<TOutputModel>(entity);
            return outputModel;
        }
        catch (Exception) { throw; }
    }

    public async Task<ContaBancaria> ListarAsync(string numeroConta)
    {
        try
        {
            var ContaBancaria = _contaBancarias.FirstOrDefault(f => f.NumeroConta == numeroConta);

            // valida 
            if (ContaBancaria is null)
                throw new Exception("Conta Bancária não encontrado!");

            return ContaBancaria;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<ContaBancaria>> ListarAsync()
    {
        try
        {
            if (_contaBancarias.Count == 0)
                throw new Exception("Nenhum Conta Bancária encontrado.");
            else
                return _contaBancarias;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> Excluir(string numeroConta)
    {
        try
        {
            var contaBancaria = _contaBancarias.FirstOrDefault(f => f.NumeroConta == numeroConta);

            // valida se existe Conta Bancária
            if (contaBancaria is null)
                throw new Exception("Conta Bancária não encontrado!");

            // remove ContaBancaria com id enviado
            _contaBancarias.RemoveAll(p => p.NumeroConta == numeroConta);
            return true;
        }
        catch (Exception) { throw; }
    }
    #endregion

    public async Task<string> Depositar(string numeroConta, double saldo)
    {
        try
        {
            // Encontrar o índice do produto com NumeroConta igual ao enviado
            int index = _contaBancarias.FindIndex(p => p.NumeroConta == numeroConta);

            if (index != -1)
                _contaBancarias[index].Saldo = _contaBancarias[index].Saldo + saldo; // Substitui o ContaBancaria antigo pelo novo
            else
                throw new Exception("Conta Bancária não encontrado!");

            return $"Saldo atual: {_contaBancarias[index].Saldo:C}";
        }
        catch (Exception) { throw; }
    }

    public async Task<string> Sacar(string numeroConta, double saque)
    {
        try
        {
            // Encontrar o índice do produto com NumeroConta igual ao enviado
            int index = _contaBancarias.FindIndex(p => p.NumeroConta == numeroConta);

            if (index != -1)
            {
                if (saque > _contaBancarias[index].Saldo)
                    throw new Exception($"Valor do saque não deve ser maior que o valor atual da conta.\nValor atual: {_contaBancarias[index].Saldo}:C");

                _contaBancarias[index].Saldo = _contaBancarias[index].Saldo - saque; // Substitui o ContaBancaria antigo pelo novo
            }
            else
                throw new Exception("Conta Bancária não encontrado!");

            return $"Saldo atual: {_contaBancarias[index].Saldo:C}";
        }
        catch (Exception) { throw; }
    }

    public async Task<string> ExibirSaldo(string numeroConta)
    {
        try
        {
            // Encontrar o índice do produto com NumeroConta igual ao enviado
            int index = _contaBancarias.FindIndex(p => p.NumeroConta == numeroConta);

            if (index != -1)
                return $"Saldo atual: {_contaBancarias[index].Saldo:C}";
            else
                throw new Exception("Conta Bancária não encontrado!");
        }
        catch (Exception) { throw; }
    }

    private static void Validacao<TValidator>(ContaBancaria entity) where TValidator : AbstractValidator<ContaBancaria>
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
