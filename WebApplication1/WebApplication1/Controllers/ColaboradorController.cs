using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _service;
    private readonly IMapper _mapper;

    public ColaboradorController(IColaboradorService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-todos")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var colaboradores = await _service.BuscarTodosColaboradoresAsync();
            if (colaboradores == null || !colaboradores.Any())
            {
                return NotFound(new
                {
                    message = "Não foi possível localizar nenhum colaborador!"
                });
            }
            else
            {
                return Ok(colaboradores);
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaboradores = await _service.BuscarColaboradoresPorIdAsync(id);
            if (colaboradores == null)
            {
                return NotFound(new
                {
                    message = $"O colaborador com id: {id} não foi encontrado!"
                });
            }
            else
            {
                return Ok(colaboradores);
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] CreateColaboradorDto colaboradorDto)
    {
        try
        {
            Colaborador colaborador = _mapper.Map<Colaborador>(colaboradorDto);
            var colaboradores = await _service.InserirColaboradorAsync(colaborador);
            if (!colaboradores)
            {
                return BadRequest("Não foi possível inserir o colaborador.");
            }
            else
            {
                return CreatedAtAction(nameof(Inserir), new { id = colaborador.ColaboradorID }, colaborador);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro interno no servidor.");
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] UpdateColaboradorDto colaboradorDto)
    {
        try
        {
            Colaborador colaborador = _mapper.Map<Colaborador>(colaboradorDto);
            var atualizacaoSucesso = await _service.AtualizarColaboradorAsync(colaborador);
            if (atualizacaoSucesso)
            {
                var colaboradorAtualizado = await _service.BuscarColaboradoresPorIdAsync(colaborador.ColaboradorID);
                return Ok(colaboradorAtualizado);
            }
            else
            {
                return BadRequest("Não foi possível atualizar o colaborador.");
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var colaboradores = await _service.ExcluirColaboradorAsync(id);
            if (!colaboradores) 
            {
                return NotFound("A empresa não foi encontrada.");
            }
            else
            {
                return Ok("Empresa removida com sucesso!");
            }
        }
        catch (Exception ex) { throw; }
    }
}

