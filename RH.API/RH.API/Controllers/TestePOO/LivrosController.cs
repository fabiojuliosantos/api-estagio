using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Validators;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly ILivroService _service;

    public LivrosController(ILivroService service)
    {
        _service = service;
    }

    [HttpGet("listar")]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var Livro = await _service.ListarAsync();
            return Ok(Livro);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CreateLivroDTO dto)
    {
        try
        {
            return Ok(await _service.CadastrarAsync<CreateLivroDTO, LivroDTO, LivroValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("emprestar")]
    public async Task<IActionResult> Emprestar(int codigoBarras)
    {
        try
        {
            Task<bool> resultadoEmprestimo = _service.Emprestar(codigoBarras);

            if (resultadoEmprestimo == Task.FromResult(true))
                return Ok("Livro emprestado com sucesso!");
            else
                throw new Exception("Não foi possível emprestar o livro!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("devolver")]
    public async Task<IActionResult> Devolver(int codigoBarras)
    {
        try
        {
            Task<bool> resultadoEmprestimo = _service.Devolver(codigoBarras);

            if (resultadoEmprestimo == Task.FromResult(true))
                return Ok("Livro emprestado com sucesso!");
            else
                throw new Exception("Não foi possível devolver o livro!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
