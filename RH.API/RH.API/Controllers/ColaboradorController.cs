using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
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

    public async Task<IActionResult> InserirColaborador([FromBody] InserirColaboradorDto colaboradorDto)
    {
        try
        {
            var respostaDTO = await _service.InserirColaborador(colaboradorDto);

            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception) { throw; }
    }
    [HttpPut("Atualizar")]

    public async Task<IActionResult> Atualizar([FromBody] AtualizarColaboradorDto colaboradorDto)
    {
        try
        {
            var respostaDTO = await _service.AtualizarColaborador(colaboradorDto);

            return respostaDTO.Sucesso ? Ok(respostaDTO) : NotFound(respostaDTO);

        }
        catch (Exception) { throw; }
    }

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var respostaDTO = await _service.ExcluirColaborador(id);
            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }

}
