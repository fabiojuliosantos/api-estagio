using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
using rh.api.Dto;
using rh.api.Services.Interface;

namespace rh.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public IActionResult AdicionarFuncionario([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return BadRequest("Dados do funcionário inválidos.");

                //Converte DTO para a entidade Funcionario (o ID é gerado automaticamente)
                var funcionario = new Funcionario(funcionarioDTO.Nome, funcionarioDTO.Cargo, funcionarioDTO.Salario);

                _funcionarioService.AdicionarFuncionario(funcionario);
                return Ok(new { Message = "Funcionário adicionado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            try
            {
                var funcionarios = _funcionarioService.ListarFuncionarios();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("media-salarial")]
        public ActionResult<decimal> CalcularMediaSalarial()
        {
            try
            {
                var valorMedia = _funcionarioService.CalcularMediaSalarial();
                var mediaArredondada = Math.Round(valorMedia, 2);
                return Ok(new { MediaSalarial = mediaArredondada });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}