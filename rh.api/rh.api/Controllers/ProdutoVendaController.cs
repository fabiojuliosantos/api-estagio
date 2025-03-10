using Microsoft.AspNetCore.Mvc;
using rh.api.Dto;
using rh.api.Services;

namespace rh.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoVendaController : ControllerBase
    {
        private readonly IProdutoVendaService _produtoVendaService;

        public ProdutoVendaController(IProdutoVendaService produtoVendaService)
        {
            _produtoVendaService = produtoVendaService;
        }

        [HttpPost("cadastrar-produtos")]
        public async Task<IActionResult> CadastrarProduto([FromBody] ProdutoVendaDto produtoDto)
        {
            try
            {
                await _produtoVendaService.CadastrarProduto(produtoDto);
                return Ok("Produto cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("vender-produtos")]
        public async Task<IActionResult> VenderProduto([FromBody] VendaRequest vendaRequest)
        {
            try
            {
                var result = await _produtoVendaService.VenderProduto(vendaRequest.ProdutoId, vendaRequest.Quantidade);
                if (result.Sucesso)
                    return Ok(result.Mensagem);
                else
                    return BadRequest(result.Mensagem);
            }
            catch (Exception) { throw; }

        }

        [HttpGet("listar-produtos")]
        public async Task<IActionResult> ListarProdutos()
        {
            try
            {
                var produtos = await _produtoVendaService.ListarProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("estoque/{produtoId}")]
        public async Task<IActionResult> ConsultarEstoque(int produtoId)
        {
            try
            {
                var produto = await _produtoVendaService.ConsultarEstoque(produtoId);
                return Ok(produto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("relatorio-vendas")]
        public async Task<IActionResult> GerarRelatorioVendas()
        {
            try
            {
                var relatorio = await _produtoVendaService.GerarRelatorioVendas();
                return Ok(relatorio);
            }
            catch (Exception) { throw; }

        }
    }
}