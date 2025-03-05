using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
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
        public IActionResult AdicionarFuncionario([FromBody] Funcionario funcionario)
        {
            try
            {
                _funcionarioService.AdicionarFuncionario(funcionario);
                return Ok(new { Message = "Funcionário adicionado com sucesso!" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            try {
                var funcionarios = _funcionarioService.ListarFuncionarios();
                return Ok(funcionarios); 
            }
            catch(Exception)
            {
                throw;
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
            catch (Exception)
            {
                //return StatusCode(500, "Ocorreu um erro ao calcular a média salarial.");
                throw;
            }
        }
    }
    }
