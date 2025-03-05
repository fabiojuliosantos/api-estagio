using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{

    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }

    [HttpGet("Mostrar-Funcionarios")]
    public async Task<IActionResult> BuscarTodosFuncionarios()
    {
        try
        {
            var funcionarios =  _service.BuscarTodosFuncionarios();

            return Ok(funcionarios);

        }
        catch (Exception)
        {

            throw;
        }  

    }

    [HttpPost("Inserir")]
    public async Task<IActionResult> InserirFuncionario([FromBody] Funcionario funcionario)
    {
        try
        {
            var resposta =  _service.InserirFuncionario(funcionario);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta); 
            }

            return Ok(resposta); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }

    [HttpGet("Média-Salarial")]

    public async Task<IActionResult> MostrarMédiaSalarial()
    {
        try
        {
            var mediaSalarial = _service.CalcularMediaSalarial();
            return Ok(mediaSalarial);
        }
        catch (Exception)
        {

            throw;
        }
    }


}
