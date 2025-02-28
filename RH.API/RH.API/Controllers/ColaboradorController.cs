using Microsoft.AspNetCore.Mvc;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

// Define a rota base para este controlador como "api/colaborador" e indica que ele é um controlador de API
[Route("api/[controller]")]
[ApiController]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _service;

    // Construtor recebe a injeção de dependência do serviço IColaboradorService
    public ColaboradorController(IColaboradorService service)
    {
        _service = service;
    }

    [HttpGet("buscar-paginado/{pagina}/{quantidade}")]
    public async Task<IActionResult> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            var colaboradores = await _service.BuscarColaboradorPorPaginaAsync(pagina, quantidade);

            if (colaboradores == null) return NotFound("Não foram encontrados colaboradores na base de dados");

            return Ok(colaboradores);
        }
        catch (Exception)
        {

            throw;
        }
    }


    [HttpGet("buscar-todos")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BuscarTodosColaboradores();
            return Ok(colaboradores);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"Erro ao buscar colaboradores: {ex.Message}" });
        }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaborador = await _service.BuscarColaboradorPorId(id);
            if (colaborador == null)
                return NotFound(new { mensagem = "Colaborador não encontrado." });

            return Ok(colaborador);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"[Controller] Erro ao buscar colaborador: {ex.Message}" });
        }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] CreateColaboradorDTO colaboradorDTO)
    {
        // Valida se o modelo recebido está correto
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            // Chama o serviço para inserir um novo colaborador
            var resultado = await _service.InserirColaborador(colaboradorDTO);
            if (!resultado)
                return BadRequest(new { mensagem = "Erro ao inserir colaborador." });

            return Ok(new { mensagem = "Colaborador inserido com sucesso." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"Erro ao inserir colaborador: {ex.Message}" });
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] UpdateColaboradorDTO colaboradorDTO)
    {
        // Valida se o modelo recebido está correto
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var resultado = await _service.AtualizarColaborador(colaboradorDTO);
            if (!resultado)
                return NotFound(new { mensagem = "Colaborador não encontrado ou erro ao atualizar." });

            return Ok(new { mensagem = "Colaborador atualizado com sucesso." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"Erro ao atualizar colaborador: {ex.Message}" });
        }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var resultado = await _service.ExcluirColaborador(id);
            if (!resultado)
                return NotFound(new { mensagem = "Colaborador não encontrado ou já excluído." });

            return Ok(new { mensagem = "Colaborador excluído com sucesso." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = $"Erro ao excluir colaborador: {ex.Message}" });
        }
    }
}
