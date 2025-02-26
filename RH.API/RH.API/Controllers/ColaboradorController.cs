using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _service;

    public ColaboradorController(IColaboradorService service)
    {
        _service = service;
    }

    [HttpGet("buscar-todos")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BuscarTodosColaboradoresAsync();
            return Ok(colaboradores);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaborador = await _service.BuscarColaboradorPorIdAsync(id);
            if (colaborador == null)
                return NotFound("Colaborador não encontrado.");

            return Ok(colaborador);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
    {
        try
        {
            var resultado = await _service.InserirColaboradorAsync(colaborador);
            if (!resultado)
                return BadRequest("Erro ao inserir colaborador.");

            return Ok("Colaborador inserido com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador)
    {
        try
        {
            var resultado = await _service.AtualizarColaboradorAsync(colaborador);
            if (!resultado)
                return BadRequest("Erro ao atualizar colaborador.");

            return Ok("Colaborador atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var resultado = await _service.ExcluirColaboradorAsync(id);
            if (!resultado)
                return NotFound("Colaborador não encontrado ou já excluído.");

            return Ok("Colaborador excluído com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
