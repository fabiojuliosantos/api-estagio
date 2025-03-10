using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProdutoService _service;

    public ProdutoController(IMapper mapper, IProdutoService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> InserirProduto([FromBody] CreateProdutoDto produtoDto)
    {
        try
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);

            bool produtoAdicionado = await _service.InserirProduto(produto);

            if (produtoAdicionado)
                return StatusCode(201, new { message = "Produto inserido com sucesso!" });
            else
                return BadRequest(new { message = "Erro ao inserir produto!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpGet("retornar")]
    public async Task<IActionResult> ExibirProdutos()
    {
        try
        {
            var produtos = await _service.BuscarTodosProdutos();

            if(produtos != null)
                return Ok(produtos);

            return NotFound(new { message = "Não há registros de produtos!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarProduto([FromBody] Produto produto)
    {
        try
        {
            var resultadoAtualizacao = await _service.AtualizarProduto(produto);

            if (resultadoAtualizacao) return Ok($"Produto atualizado com sucesso! \n {produto}");
            else return BadRequest(new { message = "O id do produto inserido não está registrado!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }
}
