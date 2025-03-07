﻿using RH.API.Domain.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface IFuncionarioService
{
    Task<bool> InserirFuncionario(Funcionario funcionario);
    Task<List<Funcionario>> BuscarTodosFuncionarios();
    Task<double> CalcularMediaSalarial();
}
