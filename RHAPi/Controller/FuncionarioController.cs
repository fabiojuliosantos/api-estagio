using Microsoft.AspNetCore.Mvc;
using RHAPi.Domain;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }

    [HttpPost("inserir")]
    public IActionResult InserirFuncionario(Funcionario funcionario)
    {
        try
        {
            var funcionarioInserido = _service.AdicionaFuncionario(funcionario);
            return Ok(funcionarioInserido);
        }
        catch (CustomerException ce)
        {
            return BadRequest(ce.Message);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar-funcionarios")]
    public IActionResult ListarFuncionarios()
    {
         try
        {
            var funcionarios = _service.ListarFuncionarios();
            return Ok(funcionarios);
        }
        catch (CustomerException ce)
        {
            return BadRequest(ce.Message);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("mostra-media-salarial")]
    public IActionResult CalculaMEdiaSalaria()
    {
        try
        {
            var mediaSalarial = _service.CalcularMediaSalaria();
            return Ok(mediaSalarial);
        }
        catch (CustomerException ce)
        {
            return BadRequest(ce.Message);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }
}