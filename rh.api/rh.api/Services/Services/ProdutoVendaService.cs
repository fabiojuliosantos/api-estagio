using rh.api.Dto;

namespace rh.api.Services
{
    public class ProdutoVendaService : IProdutoVendaService
    {
        private static List<ProdutoVenda> _produtos = new List<ProdutoVenda>();
        private static int _nextId = 1;

        public async Task CadastrarProduto(ProdutoVendaDto produtoDto)
        {
            try
            {
                if (produtoDto == null)
                    throw new ArgumentNullException(nameof(produtoDto));

                if (string.IsNullOrWhiteSpace(produtoDto.Nome))
                    throw new ArgumentException("Nome do produto é obrigatório.");

                if (produtoDto.Preco <= 0)
                    throw new ArgumentException("Preço do produto deve ser maior que zero.");

                if (produtoDto.QuantidadeEstoque < 0)
                    throw new ArgumentException("Quantidade em estoque não pode ser negativa.");

                var produto = new ProdutoVenda
                {
                    Id = _nextId++,
                    Nome = produtoDto.Nome,
                    Preco = produtoDto.Preco,
                    QuantidadeEstoque = produtoDto.QuantidadeEstoque
                };

                _produtos.Add(produto);
                await Task.CompletedTask; //Simula operação assíncrona
            }
            catch (Exception) { throw; }

        }

        public async Task<VendaResult> VenderProduto(int produtoId, int quantidade)
        {
            try
            {
                var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
                if (produto == null)
                    return new VendaResult { Sucesso = false, Mensagem = "Produto não encontrado." };

                if (quantidade <= 0)
                    return new VendaResult { Sucesso = false, Mensagem = "Quantidade deve ser maior que zero." };

                if (produto.QuantidadeEstoque < quantidade)
                    return new VendaResult { Sucesso = false, Mensagem = "Quantidade em estoque insuficiente." };

                produto.QuantidadeEstoque -= quantidade;
                produto.QuantidadeVendida += quantidade;
                produto.DataVenda = DateTime.Now;

                return new VendaResult { Sucesso = true, Mensagem = "Venda realizada com sucesso." };

            }
            catch (Exception) { throw; }

        }

        public async Task<ProdutoVenda> ConsultarEstoque(int produtoId)
        {
            try
            {
                var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
                if (produto == null)
                    throw new KeyNotFoundException("Produto não encontrado.");

                return produto;
            }
            catch (Exception) { throw; }

        }

        public async Task<List<ProdutoVenda>> GerarRelatorioVendas()
        {
            return _produtos.Where(p => p.QuantidadeVendida > 0).ToList();
        }

        public async Task<List<ProdutoVenda>> ListarProdutos()
        {
            return _produtos;
        }
    }
}