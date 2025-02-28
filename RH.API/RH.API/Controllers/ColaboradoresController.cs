using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Infra.Context;
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

    [HttpGet("buscar-paginado/{pagina}/{quantidade}")]
    public async Task<IActionResult> BuscarColaboradoresPorPagina(int pagina, int quantidade)
    {
        try
        {
            var colaboradores = await _service.BuscarColaboradoresPorPaginaAsync(pagina, quantidade);
            
            if (colaboradores == null) return NotFound("Não foram encontrados colaboradores na base de dados!");

            return Ok(colaboradores);
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("retornar")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BuscarTodosColaboradoresAsync();
            if (colaboradores != null)
                return Ok(colaboradores);

            return NotFound(new { message = "Não há colaboradores registrados!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao retornar registros!", error = ex.Message });
        }
    }


    [HttpGet("retornar/{id}")]
    public async Task<IActionResult> BuscarPorId(int id) // Utilizar FromQUery quando for parametros opcionais
    {
        try
        {
            var colaboradores = await _service.BuscarColaboradorPorId(id);
            if (colaboradores != null)
                return Ok(colaboradores);

            return NotFound(new { message = $"O colaborador com ID {id}, não foi encontrado!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao retornar registro!", error = ex.Message });
        }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> InserirColaborador([FromBody] CreateColaboradorDto colaboradorDto)
    {
        try
        {
            Colaborador colaborador = _mapper.Map<Colaborador>(colaboradorDto);

            var colaboradores = await _service.InserirColaborador(colaborador);
            return StatusCode(201, new { message = "Colaborador criado com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao inserir registro!", error = ex.Message });
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarColaborador([FromBody] Colaborador colaborador)
    {
        try
        {
            var colaboradores = await _service.AtualizarColaborador(colaborador);
            if (colaboradores != false)
                return StatusCode(204, new { message = "Colaborador atualizado com sucesso!" });

            return NotFound(new { message = "O colaborador não foi encontrado!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao atualizar registro!", error = ex.Message });
        }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> ExcluirColaborador(int id)
    {
        try
        {
            var colaboradores = await _service.ExcluirColaborador(id);
            if (colaboradores != false)
                return StatusCode(204, new { message = "Colaborador removido com sucesso!" });

            return NotFound(new { message = $"O colaborador com ID {id}, não foi encontrado!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao excluir registro!", error = ex.Message });
        }
    }
}
