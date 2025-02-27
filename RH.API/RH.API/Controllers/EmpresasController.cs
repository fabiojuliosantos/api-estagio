// APENAS EXIBIR

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresasController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpGet("retornar")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            if (empresas != null)
                return Ok(empresas);

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
            var empresas = await _service.BuscarEmpresaPorId(id);
            if (empresas != null)
                return Ok(empresas);

            return NotFound(new { message = $"A empresa com ID {id}, não foi encontrada!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao retornar registro!", error = ex.Message });
        }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> InserirEmpresa([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.InserirEmpresa(empresa);
            return StatusCode(201, new { message = "Empresa criada com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao inserir registro!", error = ex.Message });
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarEmpresa([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.AtualizarEmpresa(empresa);
            if (empresa != null)
                return StatusCode(204, new {message = "Empresa atualizada com sucesso!"});

            return NotFound(new { message = "O colaborador não foi encontrado!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao inserir registro!", error = ex.Message });
        }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> ExcluirEmpresa(int id)
    {
        try
        {
            var empresas = await _service.ExcluirEmpresa(id);
            if (empresas != false)
                return StatusCode(204, new { message = "Empresa excluida com sucesso!" });

            return NotFound(new { message = $"A empresa com ID {id}, não foi encontrada!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao inserir registro!", error = ex.Message });
        }
    }
}
