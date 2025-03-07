using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFuncionarioService _service;

    public FuncionariosController(IMapper mapper, IFuncionarioService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet("retornar")]
    public async Task<IActionResult> BuscarFuncionarios()
    {
        try
        {
            var funcionarios = await _service.BuscarTodosFuncionarios();
            if (funcionarios != null)
                return Ok(funcionarios);

            return NotFound(new { message = "Não há registros de funcionários!"});
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao retornar registros!", error = ex.Message });
        }
    }


    [HttpPost("adicionar")]
    public async Task<IActionResult> InserirFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
    {
        try
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto); // Mapeando da Dto para um objeto funcionário

            bool funcionarioAdicionado = await _service.InserirFuncionario(funcionario);

            if (funcionarioAdicionado)
                return StatusCode(201, new { message = "Funcionário inserido com sucesso!" });
            else
                return BadRequest(new { message = "Erro ao inserir registro!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro ao inserir registro!", error = ex.Message });
        }
    }

    [HttpGet("retornar-media")]
    public async Task<IActionResult> VerificarMediaSalarial()
    {
        try
        {
            double mediaSalarial = await _service.CalcularMediaSalarial();
            if (mediaSalarial != 0.0)
                return Ok($"Média salarial: R$ {mediaSalarial}");

            return NotFound(new { message = "Não há registros de funcionários!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao retornar registros!", error = ex.Message });
        }
    }
}
