using Microsoft.AspNetCore.Mvc;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("listar-todos")]
    public ActionResult<IEnumerable<ProdutoDTO>> ListarProdutos()
    {
        try
        {
            var produtos = _produtoService.ListarProdutos();
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar produtos: {ex.Message}");
        }
    }

    [HttpGet("buscar-por-nome/{nome}")]
    public ActionResult<ProdutoDTO> BuscarProdutoPorNome(string nome)
    {
        try
        {
            var produtos = _produtoService.BuscarProdutoPorNome(nome);
            if (produtos == null)
            {
                return NotFound("Produto nao encontrado");
            }
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar por produto: {ex.Message}");
        }
    }
    [HttpPost("inserir")]
    public ActionResult<ProdutoDTO> AdicionarProduto([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtos = _produtoService.AdicionarProduto(produtoDTO);
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
        }
    }

    [HttpPut("atualizar")]
    public IActionResult AtualizarProduto([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_produtoService.AtualizarProduto(produtoDTO))
            {
                return NotFound("Produto não encontrado para atualização.");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar produto: {ex.Message}");
        }
    }

    [HttpDelete("remover/{nome}")]
    public IActionResult RemoverProduto(string nome)
    {
        try
        {
            if (!_produtoService.RemoverProduto(nome))
            {
                return NotFound("produto nao encontrado");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover produto: {ex.Message}");
        }
    }

    [HttpPost("atualizar-estoque/{nome}")]
    public IActionResult AtualizarEstoque(string nome, [FromBody] int quantidade)
    {
        try
        {
            if (!_produtoService.AtualizarEstoque(nome, quantidade))
            {
                return NotFound("Produto nao encontrado no estoque");
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar estoque: {ex.Message}");
        }
    }
}
