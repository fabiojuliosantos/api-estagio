using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain;
using RH.API.Domain.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;

[Route("api/[controller]")]
[ApiController]
public class BcomsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBcomService _service;

    public BcomsController(IMapper mapper, IBcomService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> InserirConta([FromBody] CreateBcomDto BcomDto)
    {
        try
        {
            Bcom conta = _mapper.Map<Bcom>(BcomDto); // Mapeando da Dto para um objeto Bcom

            bool contaAdicionada = await _service.InserirConta(conta);

            if (contaAdicionada)
                return StatusCode(201, new { message = "Conta inserida com sucesso!" });
            else
                return BadRequest(new { message = "Erro ao inserir conta!" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("retornar-saldo/{numeroConta}")]
    public async Task<IActionResult> ExibirSaldo(string numeroConta)
    {
        try
        {
            var saldo = await _service.ExibirSaldo(numeroConta);

            if(saldo >= 0) return Ok($"Saldo da conta {numeroConta}: R${saldo}");
            else return BadRequest(new { message = "A conta inserida não está registrada!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpPut("sacar/{numeroConta}/{valorSaque}")]
    public async Task<IActionResult> Sacar(string numeroConta, string valorSaque)
    {
        try
        {
            var resultadoSaque = await _service.Sacar(numeroConta, valorSaque);
            if (resultadoSaque)
                return StatusCode(204, new { message = "Saque realizado com sucesso!" });

            return StatusCode(400, new { message = "Erro ao realizar saque!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpPut("depositar/{numeroConta}/{valorDeposito}")]
    public async Task<IActionResult> Depositar(string numeroConta, string valorDeposito)
    {
        try
        {
            var resultadoDeposito = await _service.Depositar(numeroConta, valorDeposito);
            if (resultadoDeposito)
                return StatusCode(204, new { message = "Deposito realizado com sucesso!" });

            return StatusCode(400, new { message = "Erro ao realizar deposito!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }
}
