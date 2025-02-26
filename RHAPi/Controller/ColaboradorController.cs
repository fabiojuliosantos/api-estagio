using Microsoft.AspNetCore.Mvc;
using RHAPi.Domain;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _service;

    public ColaboradorController(IColaboradorService service)
    {
        _service = service;
    }

    [HttpGet("buscar-colaboradores")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BucarTodosColaboradores();
            return Ok(colaboradores);
        }
        catch (Exception) { throw; }
    }

    [HttpGet("buscar-colarborador/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaborador = await _service.BucarColaboradorPorId(id);
            return Ok(colaborador);
        }
        catch (Exception) { throw; }
    }

    [HttpPost("inserir-colaborador")]
    public async Task<IActionResult> Inserir(Colaborador colaborador)
    {
        try
        {
            var colaboradorInserido = await _service.InserirColaborador(colaborador);
            return Ok(colaboradorInserido);
        }
        catch (Exception) { throw; }
    }

    [HttpPut("atualiza-colaborador")]
    public async Task<IActionResult> Atualizar(Colaborador colaborador)
    {
        try
        {
            var colaboradorAtualizado = await _service.AtualizarColaborador(colaborador);
            return Ok(colaboradorAtualizado);
        }
        catch (Exception) { throw; }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        try
        {
            var colaboradorDeletado = await _service.DeletarColaborador(id);
            return Ok(colaboradorDeletado);
        }
        catch (Exception) { throw; }
    }
}