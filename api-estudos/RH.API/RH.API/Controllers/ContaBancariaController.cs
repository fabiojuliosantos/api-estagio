using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaService _service;

        public ContaBancariaController(IContaBancariaService service)
        {
            _service = service;
        }

        [HttpPost("adicionar-conta")]
        public IActionResult AdicionarContaBancaria([FromBody] ContaBancaria contabancaria)
        {
            try
            {
                var resultado = _service.AdicionarContaBancaria(contabancaria);

                if (!resultado.Sucesso)
                {
                    return BadRequest(resultado.Mensagem);
                }

                return CreatedAtAction(nameof(AdicionarContaBancaria), new { mensagem = resultado.Mensagem, contabancaria });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar conta bancária.");
            }
        }

        [HttpPost("depositar/{idConta}")]
        public IActionResult Depositar(decimal valor, int idConta)
        {
            try
            {
                var resultado = _service.Depositar(idConta, valor);

                if (!resultado.Sucesso)
                {
                    return BadRequest(resultado.Mensagem);
                }

                return Ok(new { Mensagem = resultado.Mensagem, Saldo = resultado.NovoSaldo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao depositar.");
            }
        }

        [HttpPost("sacar/{idConta}")]
        public IActionResult Sacar(decimal valor, int idConta)
        {
            try
            {
                var resultado = _service.Sacar(idConta, valor);

                if (!resultado.Sucesso)
                {
                    return BadRequest(resultado.Mensagem);
                }

                return Ok(new { Mensagem = resultado.Mensagem, Saldo = resultado.NovoSaldo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao sacar.");
            }
        }

        [HttpGet("exibir-saldo/{idConta}")]
        public IActionResult ExibirSaldo(int idConta)
        {
            try
            {
                var saldo = _service.ObterSaldo(idConta);

                if (saldo == null)
                {
                    return NotFound("Conta não encontrada.");
                }

                return Ok(new { Saldo = saldo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao exibir saldo.");
            }
        }
    }
}
