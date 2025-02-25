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
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodosColaboradoresAsync();
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresas = await _service.BuscarColaboradoresPorIdAsync(id);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradores = await _service.InserirColaboradorAsync(colaborador);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradores = await _service.AtualizarColaboradorAsync(colaborador);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var colaboradores = await _service.ExcluirColaboradorAsync(id);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }
}
