using RH.API.Domain;

namespace RH.API.Services.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly List<Produto> _produtos = new List<Produto>();
        private readonly List<Venda> _vendas = new List<Venda>();
        private int nextId = 1;
        public (bool Sucesso, string Mensagem) AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                return (false, "Produto não informado");
            }

            if (produto.Nome == null)
            {
                return (false, "Nome do produto não informado");
            }
            if (produto.Preco <= 0)
            {
                return (false, "Preço do produto inválido");
            }
            if (produto.Quantidade <= 0)
            {
                return (false, "Quantidade do produto inválida");
            }
            if (_produtos.Any(p => p.Nome == produto.Nome))
            {
                return (false, "Produto já cadastrado");
            }

            _produtos.Add(produto);
            return (true, "Produto adicionado com sucesso");
        }
        public Produto ConsultarEstoque(string produtoNome)
        {
            if (produtoNome == null)
            {
                return null;
            }

            var produtoExistente = _produtos.FirstOrDefault(p => p.Nome == produtoNome);

            if (produtoExistente != null)
            {
                return produtoExistente;
            }

            return null;
        }
        public List<Venda> GerarRelatorioVendas()
        {
            return _vendas;
        }

        public List<Produto> ListarProdutos()
        {
            return _produtos;
        }

        public (bool Sucesso, string Mensagem) VenderProduto(string produtoNome, int quantidade)
        {
            if (quantidade <= 0)
            {
                return (false, "Quantidade inválida para a venda.");
            }

            var produtoExistente = _produtos.FirstOrDefault(p => p.Nome == produtoNome);

            if (produtoExistente == null)
            {
                return (false, "Produto não encontrado.");
            }

            if (produtoExistente.Quantidade < quantidade)
            {
                return (false, "Quantidade em estoque insuficiente.");
            }

            double valorTotal = produtoExistente.Preco * quantidade;

            produtoExistente.Quantidade -= quantidade;

            var venda = new Venda
            {
                Id = nextId++,
                NomeProduto = produtoExistente.Nome,
                PrecoUnitario = produtoExistente.Preco,  
                Quantidade = quantidade,
                ValorTotal = valorTotal, 
                DataVenda = DateTime.Now
            };

            _vendas.Add(venda);

            return (true, "Venda realizada com sucesso.");
        }


    }
}
