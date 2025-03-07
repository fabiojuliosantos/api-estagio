using Microsoft.AspNetCore.Mvc;
using rh.api.Services.Interface;

namespace rh.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpPost("criar-conta")]
        public IActionResult CriarConta([FromBody] CriarConta criaConta)
        {
            try
            {
                var conta = _bancoService.CriarConta(criaConta.Titular, criaConta.NumeroConta, criaConta.SaldoInicial);
                return Ok(conta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("depositar")]
        public IActionResult Depositar([FromBody] Operacao operacao)
        {
            try
            {
                var mensagem = _bancoService.Depositar(operacao.NumeroConta, operacao.Valor);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("sacar")]
        public IActionResult Sacar([FromBody] Operacao operacao)
        {
            try
            {
                var mensagem = _bancoService.Sacar(operacao.NumeroConta, operacao.Valor);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("consultar-saldo/{numeroConta}")]
        public IActionResult ConsultarSaldo(int numeroConta)
        {
            try
            {
                var mensagem = _bancoService.ConsultarSaldo(numeroConta);
                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class CriarConta    {
        public string Titular { get; set; }
        public int NumeroConta { get; set; }
        public decimal SaldoInicial { get; set; }
    }

    public class Operacao
    {
        public int NumeroConta { get; set; }
        public decimal Valor { get; set; }
    }
}

