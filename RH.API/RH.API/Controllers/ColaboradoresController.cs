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

        [HttpGet("buscar-todos")]
        public async Task<IActionResult> BuscarTodas()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradoresAsync();
                
                if(colaboradores.Count == 0) return NotFound("Não existem Colaboradores cadastrados!");
                
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
                var colaborador = await _service.BuscarColaboradorPorIdAsync(id);

                if (colaborador == null) return NotFound("O colaborador informado não está cadastrado!");

                return Ok(colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] Colaborador empresa)
        {
            try
            {
                var colaborador = await _service.InserirColaboradorAsync(empresa);
                
                return Ok(colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Colaborador empresa)
        {
            try
            {
                var colaborador = await _service.AtualizarColaboradorAsync(empresa);
                
                return Ok(colaborador);
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
                var colaborador = await _service.ExcluirColaboradorAsync(id);
                
                return Ok(colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
