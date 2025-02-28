using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
using rh.api.Services.Interface;

namespace rh.api.Controllers
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

        [HttpGet("buscar-paginado/{pagina}/{quantidade}")]
        public async Task<IActionResult> BuscarColaboradoresPorPaginaAsync(int pagina, int quantidade)
        {
            try
            {
                var colaboradores = await _service.BuscarColaboradoresPorPaginaAsync(pagina, quantidade);

                if (colaboradores == null ) 
                {
                    return NotFound("Nenhum colaborador localizado em nossa base de dados!");
                }

                return Ok(colaboradores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("buscar-todos")]
        public async Task<IActionResult> BuscarTodas()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradoresAsync();
                return Ok(colaboradores);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("buscar-id/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var colaboradores = await _service.BuscarColaboradorPorId(id);
                return Ok(colaboradores);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
        {
            try
            {
                var colaboradores = await _service.InserirColaborador(colaborador);
                return Ok(colaboradores);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador)
        {
            try
            {
                var colaboradores = await _service.AtualizarColaborador(colaborador);
                return Ok(colaboradores);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var colaboradores = await _service.ExcluirColaborador(id);
                return Ok(colaboradores);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
