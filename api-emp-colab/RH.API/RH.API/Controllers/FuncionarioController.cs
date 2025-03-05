using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Services;

namespace FuncionarioAPI.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarFuncionario([FromBody] Funcionario funcionario)
        {
            var resultado = _service.AdicionarFuncionario(funcionario);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return Ok(funcionario);
        }

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(_service.ListarFuncionarios());
        }

        [HttpGet("media-salarial")]
        public IActionResult CalcularMediaSalarial()
        {
            return Ok(new { MediaSalarial = _service.CalcularMediaSalarial() });
        }
    }
}
