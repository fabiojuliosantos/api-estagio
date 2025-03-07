using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IprodutoService _service;

    public ProdutoController(IprodutoService service)
    {
        _service = service;
    }

    [HttpPost("Adicionar-Produto")]

    public async Task<IActionResult> AdicionarProduto([FromBody]CriarProdutoDto produtoDto)
    {

        try
        {
            var resposta = _service.AdicionarProduto(produtoDto);
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

    [HttpPut("Atualizar-Produto")]

    public async Task<IActionResult> AtualizarProduto(int id ,[FromBody] Produtos produtos)
    {

        try
        {
            var resposta = _service.AtualizarProduto(id,produtos);
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

    [HttpGet("Buscar-ID")]

    public async Task<IActionResult> ExibirProdutoPorId(int produtoId)
    {

        try
        {
            var resposta = _service.ExibirProdutosPorId(produtoId);
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

    [HttpGet("Buscar-Produtos")]

    public async Task<IActionResult> ExibirTodosProdutos()
    {
        try
        {
            var produtos =  _service.ExibirTodosProdutos();
            return Ok(produtos);
        }
        catch (Exception)
        {
            throw;
        }


    }

}
