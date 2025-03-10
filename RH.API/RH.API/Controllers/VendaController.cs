using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController : ControllerBase
{
    private readonly IVendasService _service;

    public VendaController(IVendasService service)
    {
        _service = service;
    }

    [HttpGet("Relatório-Vendas{idVenda}")]

    public async Task<IActionResult> RelatorioVendas(int idVenda)
    {

        try
        {
            var vendas = _service.RelatorioVendas(idVenda);
            return Ok(vendas);
        }
        catch (Exception)
        {
            throw;
        }

    }
    [HttpGet("Estoque")]
    public async Task<IActionResult> ConsultarEstoque(int produtoId)
    {
        try
        {
            var resposta = _service.ConsultaEstoque(produtoId);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }
    [HttpPost("Vender")]
    public async Task<IActionResult> Vender(int produtoId, int quantidade)
    {
        try
        {
            var resposta = _service.VenderProduto(produtoId, quantidade);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
}
