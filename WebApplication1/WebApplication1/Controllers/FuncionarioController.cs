using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;
    private readonly IMapper _mapper;

    public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
    {
        _funcionarioService = funcionarioService;
        _mapper = mapper;
    }

    [HttpGet("buscar-funcionario")]
    public IActionResult ListarFuncionarios()
    {
        try
        {
            var funcionarios = _funcionarioService.ListarFuncionarios();
            if (funcionarios == null) return NotFound("Não foi possível localizar nenhum Funcionário.");
            return Ok(funcionarios);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost("adicionar-funcionario")]
    public IActionResult AdicionarFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
    {
        try
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);
                var sucesso = _funcionarioService.AdicionarFuncionario(funcionario);
                if (sucesso)
                {
                    return Ok(funcionario);
                }
                else
                {
                    return BadRequest("Não foi possível inserir o funcionário.");
                }
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("calcular-salario")]
    public  IActionResult CalcularSalario()
    {
        try
        {
            var funcionarios = _funcionarioService.CalcularMediaSalario();
            if (funcionarios == null) return NotFound("Não foi possível localizar nenhum Funcionário.");
            return Ok(funcionarios);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

