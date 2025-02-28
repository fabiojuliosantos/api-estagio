﻿using RH.API.Domain;

namespace RH.API.Infra.Interfaces;

public interface IEmpresaRepository
{

    Task<RetornoPaginado<Empresa>> BuscarEmpresaPorPaginaAsync(int pagina, int quantidade);
    Task<List<Empresa>> BuscarTodasEmpresas();
    Task<Empresa> BuscarEmpresaPorId(int id);
    Task<bool> InserirEmpresa(Empresa empresa);
    Task<bool> AtualizarEmpresa(Empresa empresa);
    Task<bool> ExcluirEmpresa(int id);

    Task<Empresa> BuscarPorNome(string nome);
}
