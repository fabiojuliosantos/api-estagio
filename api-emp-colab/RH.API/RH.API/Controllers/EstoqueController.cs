using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;

        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpGet("buscar/{produtoNome}")]
        public IActionResult ConsultarEstoque(string produtoNome)
        {
            try
            {
                var produto = _service.ConsultarEstoque(produtoNome);
                if (produto == null)
                    return NotFound("Produto não encontrado.");
                return Ok(produto);
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            try
            {
                var produtos = _service.ListarProdutos();
                return Ok(produtos);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                var resultado = _service.AdicionarProduto(produto);
                if (!resultado.Sucesso)
                    return BadRequest(resultado.Mensagem);
                return Ok(resultado.Mensagem);
            }
            catch (Exception ex) { throw; }
        }

        [HttpPost("vender")]
        public IActionResult VenderProduto([FromBody] VendaRequestDto vendaRequestDto)
        {
            try
            {
                var resultado = _service.VenderProduto(vendaRequestDto.ProdutoNome, vendaRequestDto.Quantidade);
                if (!resultado.Sucesso)
                    return BadRequest(resultado.Mensagem);
                return Ok(resultado.Mensagem);
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("relatorio-vendas")]
        public IActionResult GerarRelatorioVendas()
        {
            try
            {
                var vendas = _service.GerarRelatorioVendas();
                return Ok(vendas);
            }
            catch (Exception ex) { throw; }
        }
    }
}
