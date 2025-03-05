using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BcomController : ControllerBase
    {
        private readonly IBcom _bcomService;

        public BcomController(IBcom bcomService)
        {
            _bcomService = bcomService;
        }

        [HttpPost("adicionar-conta")]
        public IActionResult AdicionarConta([FromBody] Bcom bcom)
        {
            try
            {
                var resultado = _bcomService.AdicionarConta(bcom);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpPost("depositar")]
        public IActionResult Depositar([FromQuery] int numeroConta, [FromQuery] double valor)
        {
            try
            {
                var resultado = _bcomService.Depositar(numeroConta, valor);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpGet("exibir-saldo")]
        public IActionResult ExibirSaldo([FromQuery] int numeroConta)
        {
            try
            {
                double saldo = _bcomService.ExibirSaldo(numeroConta);
                return Ok(new { Saldo = saldo });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpGet("listar-contas")]
        public IActionResult ListarContasBancarias()
        {
            try
            {
                var contas = _bcomService.ListarContasBancarias();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpPost("sacar")]
        public IActionResult Sacar([FromQuery] int numeroConta, [FromQuery] double valor)
        {
            try
            {
                var resultado = _bcomService.Sacar(numeroConta, valor);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }
    }
}

