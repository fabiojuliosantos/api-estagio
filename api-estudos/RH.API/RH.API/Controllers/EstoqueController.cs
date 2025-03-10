using Microsoft.AspNetCore.Mvc;
using RH.API.Services.Interface;
using RH.API.Dto;
using System;
using System.Linq;
using RH.API.Domain;

namespace RH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarProduto([FromBody] EstoqueDto estoqueDto)
        {
            try
            {
                if (string.IsNullOrEmpty(estoqueDto.Nome))
                    return BadRequest("O nome do produto não pode ser vazio.");

                if (estoqueDto.Preco <= 0)
                    return BadRequest("O preço do produto deve ser maior que zero.");

                if (estoqueDto.QtdEstoque < 0)
                    return BadRequest("A quantidade em estoque não pode ser negativa.");

                var resultado = _estoqueService.AdicionarProduto(estoqueDto);
                if (resultado.Sucesso)
                    return CreatedAtAction(nameof(AdicionarProduto), new { mensagem = resultado.Mensagem, estoqueDto });

                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar produto: {ex.Message}");
            }
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] EstoqueUpdateDto estoqueUpdateDto)
        {
            try
            {
                // Validação
                if (string.IsNullOrEmpty(estoqueUpdateDto.Nome))
                    return BadRequest("O nome do produto não pode ser vazio.");

                if (estoqueUpdateDto.Preco <= 0)
                    return BadRequest("O preço do produto deve ser maior que zero.");

                if (estoqueUpdateDto.QtdEstoque < 0)
                    return BadRequest("A quantidade em estoque não pode ser negativa.");

                var resultado = _estoqueService.AtualizarProduto(id, estoqueUpdateDto);
                if (resultado.Sucesso)
                    return CreatedAtAction(nameof(AdicionarProduto), new { mensagem = resultado.Mensagem, estoqueUpdateDto });

                return NotFound(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar produto: {ex.Message}");
            }
        }

        [HttpGet("todos")]
        public IActionResult ObterProdutos()
        {
            try
            {
                var resultado = _estoqueService.ObterProdutos();
                if (resultado.Sucesso)
                    return Ok(resultado.Produtos);

                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter produtos: {ex.Message}");
            }
        }


        [HttpGet("consulta/{produtoId}")]
        public IActionResult ConsultarEstoque(int produtoId)
        {
            try
            {
                var resultado = _estoqueService.ConsultarEstoque(produtoId);
                if (resultado.Sucesso)
                {
                    var produtoDto = new
                    {
                        produtoId = resultado.Produto.Id,
                        nomeProduto = resultado.Produto.Nome,
                        quantidadeEstoque = resultado.Produto.QtdEstoque
                    };

                    return CreatedAtAction(nameof(ConsultarEstoque), new { produtoId = produtoId }, produtoDto);
                }

                return NotFound(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar estoque: {ex.Message}");
            }
        }


        [HttpPost("vender/{produtoId}")]
        public IActionResult VenderProduto(int produtoId, [FromQuery] int quantidade)
        {
            try
            {
                if (quantidade <= 0)
                    return BadRequest("A quantidade de venda deve ser maior que zero.");

                var resultado = _estoqueService.VenderProduto(produtoId, quantidade);
                if (resultado.Sucesso)
                    return CreatedAtAction(nameof(VenderProduto), new { mensagem = resultado.Mensagem, produtoId });

                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao realizar a venda: {ex.Message}");
            }
        }

        [HttpGet("relatorio-vendas")]
        public IActionResult GerarRelatorioVendas()
        {
            try
            {
                var relatorio = _estoqueService.GerarRelatorioVendas();
                if (relatorio != null && relatorio.Any())
                    return Ok(relatorio);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao gerar relatório de vendas: {ex.Message}");
            }
        }

    }
}
