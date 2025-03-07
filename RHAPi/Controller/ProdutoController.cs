using Microsoft.AspNetCore.Mvc;
using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpPost("adicionar-produto")]
    public IActionResult AdicionarProduto(CreateProdutoDto createProdutoDto)
    {
        try
        {
            Produto produto = _service.AdicionarProdutos(createProdutoDto);
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar-produtos")]
    public IActionResult ListarProdutosEmEstoque()
    {
        try
        {
            return Ok(_service.ExibirProdutosDisponiveis());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar-produto-estoque")]
    public IActionResult AtualizarProdutoEmEstoque(UpdateProdutoDto updateProdutoDto)
    {
        try
        {
            return Ok(_service.AtualizarProdutoEmEstoque(updateProdutoDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}