using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();
        private static int proximoId = 1;

        // Adicionar Produto
        [HttpPost]
        public ActionResult<ProdutoGetDto> AdicionarProduto([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var produto = new Produto
                {
                    Id = proximoId++,
                    Nome = produtoDto.Nome,
                    Preco = produtoDto.Preco,
                    QtdEstoque = produtoDto.QtdEstoque
                };

                produtos.Add(produto);

                var produtoGetDto = new ProdutoGetDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    QtdEstoque = produto.QtdEstoque
                };

                return CreatedAtAction(nameof(ExibirProdutos), new { id = produto.Id }, produtoGetDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Exibir produtos disponíveis
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoGetDto>> ExibirProdutos()
        {
            try
            {
                var produtosDisponiveis = produtos.Select(p => new ProdutoGetDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    QtdEstoque = p.QtdEstoque
                }).ToList();

                return Ok(produtosDisponiveis);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarProduto(int id, [FromBody] ProdutoUpdateDto produtoUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var produto = produtos.FirstOrDefault(p => p.Id == id);
                if (produto == null)
                    return NotFound("Produto não encontrado.");

                produto.Nome = produtoUpdateDto.Nome;
                produto.Preco = produtoUpdateDto.Preco;
                produto.QtdEstoque = produtoUpdateDto.QtdEstoque;

                return Ok("Produto atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}

