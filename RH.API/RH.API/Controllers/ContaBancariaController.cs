using Microsoft.AspNetCore.Mvc;
using RH.API.Domain.Entities;
using RH.API.Domain.Validators;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContaBancariaController : ControllerBase
{
    private readonly IContaBancariaService _service;

    public ContaBancariaController(IContaBancariaService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] ContaBancaria dto)
    {
        try
        {
            return Ok(await _service.InserirAsync<ContaBancaria, ContaBancaria, ContaBancariaValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("exibir-saldo/{numeroConta}")]
    public async Task<IActionResult> ExibirSaldo(string numeroConta)
    {
        try
        {
            return Ok(await _service.ExibirSaldo(numeroConta));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("depositar/{numeroConta}/{saldo:double}")]
    public async Task<IActionResult> Depositar(string numeroConta, double saldo)
    {
        try
        {
            return Ok(await _service.Depositar(numeroConta, saldo));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("sacar/{numeroConta}/{saldo:double}")]
    public async Task<IActionResult> Sacar(string numeroConta, double saldo)
    {
        try
        {
            return Ok(await _service.Sacar(numeroConta, saldo));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
