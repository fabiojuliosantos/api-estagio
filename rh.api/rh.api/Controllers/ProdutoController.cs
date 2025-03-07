using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
using rh.api.Dto;
using rh.api.Services.Interface;

namespace rh.api.Controllers
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

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            try
            {
                var produtos = _produtoService.ListarProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var produtoAdicionado = _produtoService.AdicionarProduto(produtoDto);
                return Ok(produtoAdicionado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/atualizar-estoque")]
        public IActionResult AtualizarEstoque(int id, [FromBody] ProdutoDto produtoDto)
        {
            try
            {
                var produtoAtualizado = _produtoService.AtualizarEstoque(id, produtoDto);
                return Ok(produtoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}