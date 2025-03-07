using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProdutoController : Controller
{
    private readonly IProdutoService _service;
    private readonly IMapper _mapper;

    public ProdutoController(IProdutoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-produtos")]
    public IActionResult ExibirProdutos()
    {
        try
        {
            var produtos = _service.ExibirProdutos();
            return Ok(produtos);
        }
        catch (Exception e) { throw; }
    }

    [HttpPost("adicionar-produto")]
    public IActionResult AdicionarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        try
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            var resposta = _service.AdicionarProdutos(produto);
            return Ok(resposta);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("atualizar-produto")]
    public IActionResult AtualizarProduto([FromBody] UpdateProdutoDto produtoDto)
    {
        try
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            var resposta = _service.AtualizarProduto(produto);
            return Ok(resposta);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
