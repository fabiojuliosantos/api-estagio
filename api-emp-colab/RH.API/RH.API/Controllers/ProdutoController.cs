using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost("adicionar-produto")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                var resultado = _produtoService.AdicionarProduto(produto);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpPost("atualizar-estoque")]
        public IActionResult AtualizarEstoque([FromQuery] string nomeProduto, [FromQuery] int quantidadeAlteracao)
        {
            try
            {
                var produtos = _produtoService.ListarProdutos();
                var resultado = _produtoService.AtualizarEstoque(produtos, nomeProduto, quantidadeAlteracao);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpGet("listar-produtos")]
        public IActionResult ListarProdutos()
        {
            try
            {
                var produtos = _produtoService.ListarProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }
    }
}
