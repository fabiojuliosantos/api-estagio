using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BcomController : ControllerBase
{
    private readonly IbcomService _service;

    public BcomController(IbcomService service)
    {
        _service = service;
    }

    [HttpPost("Inserir")]
    
    public async Task<IActionResult> CriarConta([FromBody] Bcom bcom)
    {
        try
        {
            var resposta = _service.CriarConta(bcom);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }

    [HttpPost("Depositar")]

    public async Task<IActionResult> Depositar(int numeroConta, double valor)
    {
        try
        {
            var resposta = _service.Depositar(numeroConta, valor);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }



    }

    [HttpPost("Sacar")]

    public async Task<IActionResult> Sacar(int numeroConta, double saque)
    {
        try
        {
            var resposta = _service.Sacar(numeroConta, saque);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }

    [HttpGet("Mostrar-saldo")]
    
    public async Task<IActionResult> ExibirSaldo(int numeroConta)
    {

        try
        {
            var resposta = _service.ExibirSaldo(numeroConta);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }



}
