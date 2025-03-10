using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;
[Route("api/[controller]")]
[ApiController]


public class VendaController : Controller
{
    private readonly IVendaService _service;
    private readonly IMapper _mapper;
    private readonly IProdutoService _produtoService;

    public VendaController(IVendaService service, IMapper mapper, IProdutoService produtoService)
    {
        _service = service;
        _mapper = mapper;
        _produtoService = produtoService;
    }

    [HttpPost("adicionar-venda")]
    public IActionResult AdicionarVenda([FromBody] CreateVendaDto vendaDto)
    {
        try
        {
            var venda = _mapper.Map<Venda>(vendaDto);
            var produto = _produtoService.ExibirProdutoPorId(venda.IdProduto);
            if (produto.QuantidadeEmEstoque < venda.Quantidade)
            {
                return BadRequest("O produto não tem disponível a quantidade desejada.");
            }
            else
            {
                var produtoVendido = _produtoService.VenderProduto(venda.IdProduto, venda.Quantidade);
                venda.ValorTotal = (produtoVendido.Preco * venda.Quantidade);
                var resultado = _service.AdicionarNovaVenda(venda);
                return Ok(resultado);
            }
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("exibir-relatorio")]
    public IActionResult ExibirRelatorio()
    {
        try
        {
            var vendas = _service.GerarRelatório();
            return Ok(vendas);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpGet("consulta-estoque")]
    public IActionResult ConsultarEstoque([FromQuery] int idProduto)
    {
        try
        {
            var produto = _produtoService.ExibirProdutoPorId(idProduto);
            return Ok(produto);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
