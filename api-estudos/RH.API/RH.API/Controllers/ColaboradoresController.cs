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
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradores();
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("buscar-id/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var colaboradores = await _service.BuscarColaboradorPorId(id);

                if (colaboradores == null)
                {
                    return NotFound(new { message = "Colaborador não encontrado." });
                }

                return Ok(colaboradores);
            }
            catch (Exception) { throw; }
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
        {
            try
            {
                var colaboradores = await _service.InserirColaborador(colaborador);
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }
        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador)
        {
            try
            {
                var colaboradores = await _service.AtualizarColaborador(colaborador);
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }
        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var colaboradores = await _service.ExcluirColaborador(id);
                return Ok(colaboradores);
            }
            catch (Exception ex) { throw; }
        }
    }
}