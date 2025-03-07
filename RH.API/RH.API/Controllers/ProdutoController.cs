using Microsoft.AspNetCore.Mvc;
using RH.API.Domain.Validators;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var Produto = await _service.ListarAsync();
            return Ok(Produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Listar(int id)
    {
        try
        {
            var Produto = await _service.ListarAsync(id);
            return Ok(Produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] CreateProdutoDTO dto)
    {
        try
        {
            return Ok(await _service.InserirAsync<CreateProdutoDTO, ProdutoDTO, ProdutoValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] ProdutoDTO dto)
    {
        try
        {
            return Ok(await _service.AtualizarAsync<ProdutoDTO, ProdutoDTO, ProdutoValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            return Ok(await _service.Excluir(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
