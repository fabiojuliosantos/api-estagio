using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BcomController : Controller
{
    private readonly IBcomService _service;
    private readonly IMapper _mapper;

    public BcomController(IBcomService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    [HttpGet("exibir-saldo")]
    public IActionResult ExibirSaldo([FromQuery] int numeroDaConta)
    {
        try
        {
            var bcom = _service.ExibirSaldo(numeroDaConta);
            if (bcom == null) return NotFound($"Não foi possível localizar a conta de número {numeroDaConta}.");
            else return Ok(bcom);
        }
        catch (Exception e) { throw; }
    }
    [HttpPost("adicionar-conta")]
    public IActionResult AdicionarConta([FromBody] CreateBcomDto bcomDto)
    {
        try
        {
            var bcom = _mapper.Map<Bcom>(bcomDto);
            int resposta = _service.CriarConta(bcom);
            switch (resposta)
            {
                case 1:
                    return Ok(bcom);
                case 2:
                    return BadRequest("Digite uma conta válida!");
                case 3:
                    return BadRequest("O número da conta já existe!");
            }
            return Ok(bcom);
        }
        catch (Exception e) { throw; }
    }

    [HttpPut("depositar")]
    public IActionResult Depositar([FromQuery] int numeroDaConta, [FromQuery] double valor)
    {
        try
        {
            if (numeroDaConta < 1 || numeroDaConta > int.MaxValue) return BadRequest("Número da conta inválido!");
            if (valor < 0 || valor > double.MaxValue) return BadRequest("Valor inválido!");
            var resposta = _service.Depositar(numeroDaConta, valor);
            if (resposta) return Ok("Saldo alterado com sucesso!");
            else return BadRequest($"Não foi possível localizar a conta com o número {numeroDaConta}.");
        }
        catch (Exception e) { throw; }
    }

    [HttpPut("sacar")]
    public IActionResult Sacar([FromQuery] int numeroDaConta, [FromQuery] double valor)
    {
        try
        {
            if (numeroDaConta < 1 || numeroDaConta > int.MaxValue) return BadRequest("Número da conta inválido!");
            if (valor < 0 || valor > double.MaxValue) return BadRequest("Valor inválido!");
            var resposta = _service.Sacar(numeroDaConta, valor);
            if (resposta == 1) return Ok("Saldo alterado com sucesso!");
            else if (resposta == 2) return BadRequest($"Saldo insuficiente.");
            else return BadRequest($"Não foi possível localizar a conta com o número {numeroDaConta}.");
        }
        catch (Exception e) { throw; }
    }


}
