﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;
using RH.API.Validacao;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorPorId(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradoresAsync()
    {
        try
        {
            return await _repository.BuscarTodosColaboradores();
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        try
        {
            Validacoes validacao = new();
            // Fazer validação para o cpf do colaborador

            bool validacaoCpf = validacao.ValidaCpf(colaborador.Cpf);

            if (validacaoCpf)
                return await _repository.InserirColaborador(colaborador);
            else
                throw new Exception("Cpf inválido!");
        }
        catch (Exception ex) { throw; }
    }
}
