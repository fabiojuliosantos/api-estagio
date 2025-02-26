using Microsoft.AspNetCore.Http;
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

    [HttpGet("Buscar-todos")]

    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaborador = await _service.BuscarTodosColaborador();
            return Ok(colaborador);


        }
        catch (Exception) { throw; }

    }
    [HttpGet("Buscar-id/{id}")]

    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaboradorId = await _service.BuscarColaboradorId(id);
            return Ok(colaboradorId);

        }
        catch (Exception) { throw; }
    }
    [HttpPost("Adicionar")]

    public async Task<IActionResult> Inserir([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradorInserir = await _service.InserirColaborador(colaborador);
            return Ok(colaboradorInserir);


        }
        catch (Exception) { throw; }
    }
    [HttpPut("Atualizar")]

    public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador) {
        try { 
        var colaboradorAtualizar = await _service.AtualizarColaborador(colaborador);
        return Ok(colaboradorAtualizar);
        }catch(Exception ) { throw;  }
    }

    [HttpPut("Excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var colaboradorExcluido = await _service.ExcluirColaborador(id);
            return Ok(colaboradorExcluido);



        }catch(Exception) { throw; }

    }

}
