using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorService _service;

        public ColaboradoresController(IColaboradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarColaboradores()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradores();
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("colaborador-id/{id}")]
        public async Task<IActionResult> ColaboradorPorId(int id)
        {
            try
            {
                var colaboradores = await _service.BuscarColaboradoresPorId(id);
                return Ok(colaboradores);
            }
            catch (Exception) { throw; }
        }

        [HttpPost("inserir-colaborador")]
        public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
        {
            try
            {
                var colabs = await _service.InserirColaborador(colaborador);
                return Ok(colabs);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPut("atualizar-colaborador")]
        public async Task<IActionResult> Atualizar([FromBody] Colaborador colab)
        {
            try
            {
                var colabs = await _service.AtualizarColaborador(colab);
                return Ok(colabs);
            }
            catch (Exception ex) { throw; }
        }
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirColaborador(int id)
        {
            try
            {
                var colab = await _service.ExcluirColaborador(id);
                return Ok(colab);
            }
            catch (Exception ex) { throw; }
        }
    }
}
