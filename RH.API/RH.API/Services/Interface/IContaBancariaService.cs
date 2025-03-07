using RH.API.Domain;
using RH.API.DTOs;
using System.Collections.Generic;

namespace RH.API.Services.Interface;

public interface IContaBancariaService
{
    IEnumerable<ContaBancariaDTO> ListarContas();
    ContaBancariaDTO BuscarContaPorNumero(string numeroConta);
    ContaBancariaDTO AdicionarConta(ContaBancariaDTO contaDTO);
    bool AtualizarConta(ContaBancariaDTO contaDTO);
    bool RemoverConta(string numeroConta);
    void Depositar(string numeroConta, double valor);
    bool Sacar(string numeroConta, double valor);
    double ConsultarSaldo(string numeroConta);
}