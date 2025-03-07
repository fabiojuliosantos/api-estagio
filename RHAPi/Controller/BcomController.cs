using Microsoft.AspNetCore.Mvc;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;


[ApiController]
[Route("api/[controller]")]
public class BcomController : ControllerBase
{
    private readonly IBcomService _service;

    public BcomController(IBcomService service)
    {
        _service = service;
    }

    [HttpPost("cria-conta")]
    public IActionResult CriaContaBancaria(CreateBcomDto contaBancaria)
    {
        try
        {
            var contaCriada = _service.CriarConta(contaBancaria);
            return Ok(contaCriada);
            
        }
        catch (Exception ex)
        {
           return BadRequest(ex.Message);
        }
    }

    [HttpPost("deposita-conta")]
    public IActionResult DepositaBcom(decimal valorDeposito, string numeroConta)
    {
        try
        {
            return Ok(_service.Depositar(valorDeposito, numeroConta));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("exibi-saldo-conta")]
    public IActionResult ExibirSaldoBcom(string numeroConta)
    {
        try
        {
            return Ok(_service.ExibirSaldo(numeroConta));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("saca-conta")]
    public IActionResult SacarBcom(decimal ValorSaque, string numeroConta)
    {
        try
        {
            return Ok(_service.Sacar(ValorSaque, numeroConta));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}