using Microsoft.AspNetCore.Mvc;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/{controller}")]
[ApiController]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;

    public EstoqueController(IEstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }

    [HttpGet("listar-produtos")]
    public ActionResult<IEnumerable<ProdutoDTO>> ListarProdutos()
    {
        try
        {
            var produtos = _estoqueService.ListarProdutos();
            return Ok(produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar produtos: {ex.Message}");
        }
    }
    [HttpGet("buscar-produtos/{nome}")]
    public ActionResult<ProdutoDTO> BuscarProdutoPorNome(string nome)
    {
        try
        {
            var produto = _estoqueService.BuscarProdutoPorId(nome);
            if (produto == null)
            {
                return NotFound("Produto nao encontrado");
            }
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar produto por nome: {ex.Message}");
        }
    }
    [HttpPost("adicionar-produto")]
    public ActionResult<ProdutoDTO> AdicionarProduto([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var produto = _estoqueService.AdicionarProduto(produtoDTO);
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
        }
    }
    [HttpPut("atualizar-produto")]
    public IActionResult AtualizarProduto([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_estoqueService.AtualizarProduto(produtoDTO))
            {
                return NotFound("Produto nao encontrado para atualizacao.");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar produto: {ex.Message}");
        }
    }
    [HttpDelete("remover-produto/{nome}")]
    public IActionResult RemoverProduto(string nome)
    {
        try
        {
            if(!_estoqueService.RemoverProduto(nome))
            {
                return NotFound("Produto nao encontrado");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover produto: {ex.Message}");
        }
    }
    [HttpPost("realizar-venda")]
    public IActionResult RealizarVenda([FromBody] VendaDTO vendaDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_estoqueService.RealizarVenda(vendaDTO.NomeProduto, vendaDTO.Quantidade))
            {
                return BadRequest("Produto nao disponivel em estoque ou quantidade");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao realizar venda: {ex.Message}");
        }
    }
    [HttpGet("relatorio-vendas")]
    public ActionResult<IEnumerable<VendaDTO>> GerarRelatorioVendas()
    {
        try
        {
            var vendas = _estoqueService.GerarRelatorioVendas();
            return Ok(vendas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao gerar relatorio de vendas: {ex.Message}");
        }
    }
}
