using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet("listar-todos")]
    public ActionResult<IEnumerable<Funcionario>> ListarFuncionarios()
    {
        try
        {
            return Ok(_funcionarioService.ListarFuncionarios());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar funcionários: {ex.Message}");
        }
    }

    [HttpGet("Buscar-id/{id}")]
    public ActionResult<IEnumerable<Funcionario>> BuscarFuncionarioPorId(int id)
    {
        try
        {
            var funcionario = _funcionarioService.BuscarFuncionariosPorId(id);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }
            return Ok(funcionario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar funcionário por ID: {ex.Message}");
        }
    }

    [HttpPost("inserir")]
    public ActionResult<IEnumerable<Funcionario>> AdicionarFuncionario([FromBody] Funcionario funcionario)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var novoFuncionario = _funcionarioService.AdicionarFuncionario(funcionario);
            return CreatedAtAction(nameof(BuscarFuncionarioPorId),
                new { id = novoFuncionario.Id }, novoFuncionario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao inserir funcionário: {ex.Message}");
        }
    }

    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarFuncionario(int id, [FromBody] Funcionario funcionario)
    {
        try
        {
            if (id != funcionario.Id)
            {
                return BadRequest("Id incorreto. Favor verificar!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_funcionarioService.AtualizarFuncionario(funcionario))
            {
                return NotFound("Funcionário não encontrado para atualização.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar funcionário: {ex.Message}");
        }
    }

    [HttpGet("media-salarial")]
    public ActionResult<double> CalcularMediaSalarial()
    {
        try
        {
            return Ok(_funcionarioService.CalcularMediaSalarial());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao calcular a média salarial: {ex.Message}");
        }
    }
}