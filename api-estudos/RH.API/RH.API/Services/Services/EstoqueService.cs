using AutoMapper;
using RH.API.Domain;
using RH.API.Dto;

namespace RH.API.Services
{
    public class EstoqueService : IEstoqueService
    {
        private static List<Estoque> estoque = new List<Estoque>();
        private static List<Venda> vendas = new List<Venda>();
        private static int proximoIdProduto = 1;
        private static int proximoIdVenda = 1;
        private readonly IMapper _mapper;

        public EstoqueService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public (bool Sucesso, string Mensagem, EstoqueGetDto Produto) AdicionarProduto(EstoqueDto estoqueDto)
        {
            var produto = _mapper.Map<Estoque>(estoqueDto); // Usando AutoMapper para mapear EstoqueDto para Estoque
            produto.Id = proximoIdProduto++;
            estoque.Add(produto);

            var produtoGetDto = _mapper.Map<EstoqueGetDto>(produto); // Usando AutoMapper para mapear Estoque para EstoqueGetDto

            return (true, "Produto adicionado com sucesso.", produtoGetDto);
        }

        public (bool Sucesso, string Mensagem) AtualizarProduto(int id, EstoqueUpdateDto estoqueUpdateDto)
        {
            var produto = estoque.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return (false, "Produto não encontrado.");

            produto = _mapper.Map(estoqueUpdateDto, produto); // Usando AutoMapper para atualizar produto com EstoqueUpdateDto

            return (true, "Produto atualizado com sucesso.");
        }

        public (bool Sucesso, string Mensagem, IEnumerable<EstoqueGetDto> Produtos) ObterProdutos()
        {
            var produtosGetDto = _mapper.Map<IEnumerable<EstoqueGetDto>>(estoque); // Usando AutoMapper para mapear a lista

            return (true, "Produtos obtidos com sucesso.", produtosGetDto);
        }

        public (bool Sucesso, string Mensagem, EstoqueGetDto Produto) ConsultarEstoque(int produtoId)
        {
            var produto = estoque.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null)
                return (false, "Produto não encontrado.", null);

            var produtoGetDto = _mapper.Map<EstoqueGetDto>(produto); // Usando AutoMapper

            return (true, "Produto encontrado no estoque.", produtoGetDto);
        }

        public (bool Sucesso, string Mensagem) VenderProduto(int produtoId, int quantidade)
        {
            var produto = estoque.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null)
                return (false, "Produto não encontrado.");

            if (produto.QtdEstoque < quantidade)
                return (false, "Quantidade insuficiente no estoque.");

            produto.QtdEstoque -= quantidade;

            // Registrar a venda
            var venda = new Venda
            {
                Id = proximoIdVenda++,
                ProdutoId = produtoId,
                Quantidade = quantidade,
                ValorTotal = produto.Preco * quantidade,
            };

            vendas.Add(venda);

            return (true, "Venda realizada com sucesso.");
        }

        public IEnumerable<RelatorioVendaDto> GerarRelatorioVendas()
        {
            var relatorio = vendas
                .GroupBy(v => v.ProdutoId)
                .Select(g => new RelatorioVendaDto
                {
                    NomeProduto = estoque.First(p => p.Id == g.Key).Nome,
                    QuantidadeVendida = g.Sum(v => v.Quantidade),
                    ValorTotal = g.Sum(v => v.ValorTotal)
                });

            return relatorio;
        }
    }
}
