using Microsoft.AspNetCore.Mvc;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaService _contaBancariaService;

        public ContaBancariaController(IContaBancariaService contaBancariaService)
        {
            _contaBancariaService = contaBancariaService;
        }

        [HttpGet("listar-todas")]
        public ActionResult<IEnumerable<ContaBancariaDTO>> ListarContas()
        {
            try
            {
                var contas = _contaBancariaService.ListarContas();
                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar contas: {ex.Message}");
            }
        }

        [HttpGet("buscar-por-numero/{numeroConta}")]
        public ActionResult<ContaBancariaDTO> BuscarContaPorNumero(string numeroConta)
        {
            try
            {
                var conta = _contaBancariaService.BuscarContaPorNumero(numeroConta);
                if (conta == null)
                {
                    return NotFound("Conta não encontrada.");
                }
                return Ok(conta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar conta por número: {ex.Message}");
            }
        }

        [HttpPost("inserir")]
        public ActionResult<ContaBancariaDTO> AdicionarConta([FromBody] ContaBancariaDTO contaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var novaConta = _contaBancariaService.AdicionarConta(contaDTO);
                return Ok(novaConta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao inserir conta: {ex.Message}");
            }
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarConta([FromBody] ContaBancariaDTO contaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_contaBancariaService.AtualizarConta(contaDTO))
                {
                    return NotFound("Conta não encontrada para atualização.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar conta: {ex.Message}");
            }
        }

        [HttpDelete("remover/{numeroConta}")]
        public IActionResult RemoverConta(string numeroConta)
        {
            try
            {
                if (!_contaBancariaService.RemoverConta(numeroConta))
                {
                    return NotFound("Conta não encontrada para remoção.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover conta: {ex.Message}");
            }
        }

        [HttpPost("depositar/{numeroConta}")]
        public IActionResult Depositar(string numeroConta, [FromBody] double valor)
        {
            try
            {
                _contaBancariaService.Depositar(numeroConta, valor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao depositar: {ex.Message}");
            }
        }

        [HttpPost("sacar/{numeroConta}")]
        public IActionResult Sacar(string numeroConta, [FromBody] double valor)
        {
            try
            {
                if (!_contaBancariaService.Sacar(numeroConta, valor))
                {
                    return BadRequest("Saldo insuficiente para o saque.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao sacar: {ex.Message}");
            }
        }

        [HttpGet("consultar-saldo/{numeroConta}")]
        public ActionResult<double> ConsultarSaldo(string numeroConta)
        {
            try
            {
                var saldo = _contaBancariaService.ConsultarSaldo(numeroConta);
                return Ok(saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar saldo: {ex.Message}");
            }
        }
    }
}