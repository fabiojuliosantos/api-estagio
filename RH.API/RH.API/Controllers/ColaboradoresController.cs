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

    [HttpGet("retornar")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BuscarTodosColaboradoresAsync();
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }


    [HttpGet("retornar/{id}")]
    public async Task<IActionResult> BuscarPorId(int id) // Utilizar FromQUery quando for parametros opcionais
    {
        try
        {
            var colaboradores = await _service.BuscarColaboradorPorId(id);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> InserirColaborador([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradores = await _service.InserirColaborador(colaborador);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarColaborador([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradores = await _service.AtualizarColaborador(colaborador);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> ExcluirColaborador(int id)
    {
        try
        {
            var colaboradores = await _service.ExcluirColaborador(id);
            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }
}
