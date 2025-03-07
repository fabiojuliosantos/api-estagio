using rh.api.Domain;
using rh.api.Dto;
using rh.api.Services.Interface;

namespace rh.api.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _nextId = 1;

        public List<Produto> ListarProdutos()
        {
            return _produtos;
        }

        public Produto AdicionarProduto(ProdutoDto produtoDto)
        {
            try
            {
                //Validações Solicitadas
                if (string.IsNullOrEmpty(produtoDto.Nome))
                    throw new ArgumentException("O nome do produto não pode ser nulo ou vazio.");

                if (produtoDto.Preco <= 0)
                    throw new ArgumentException("O preço do produto deve ser maior que zero.");

                if (produtoDto.QuantidadeEstoque < 0)
                    throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

                //Cria o produto 
                var produto = new Produto
                {
                    Id = _nextId++,
                    Nome = produtoDto.Nome,
                    Preco = produtoDto.Preco,
                    QuantidadeEstoque = produtoDto.QuantidadeEstoque
                };

                _produtos.Add(produto);
                return produto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProdutoDto AtualizarEstoque(int id, ProdutoDto produtoDto)
        {
            try
            {
                var produtoExistente = _produtos.Find(p => p.Id == id);
                if (produtoExistente == null)
                    throw new ArgumentException("Produto não encontrado.");

                //Atualiza apenas os campos desejados
                if (produtoDto.QuantidadeEstoque >= 0)
                    produtoExistente.QuantidadeEstoque = produtoDto.QuantidadeEstoque;

                if (!string.IsNullOrEmpty(produtoDto.Nome))
                    produtoExistente.Nome = produtoDto.Nome;

                if (produtoDto.Preco > 0)
                    produtoExistente.Preco = produtoDto.Preco;

                //Retorna um ProdutoDto
                return new ProdutoDto
                {
                    Nome = produtoExistente.Nome,
                    Preco = produtoExistente.Preco,
                    QuantidadeEstoque = produtoExistente.QuantidadeEstoque
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}