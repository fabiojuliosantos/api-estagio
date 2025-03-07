using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private static List<Produto> produtos = new List<Produto>();
        private static int proximoId = 1;

        public (bool Sucesso, string Mensagem, ProdutoGetDto Produto) AdicionarProduto(ProdutoDto produtoDto)
        {
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

            return (true, "Produto adicionado com sucesso.", produtoGetDto);
        }

        public (bool Sucesso, string Mensagem) AtualizarProduto(int id, ProdutoUpdateDto produtoUpdateDto)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return (false, "Produto não encontrado.");

            produto.Nome = produtoUpdateDto.Nome;
            produto.Preco = produtoUpdateDto.Preco;
            produto.QtdEstoque = produtoUpdateDto.QtdEstoque;

            return (true, "Produto atualizado com sucesso.");
        }

        public (bool Sucesso, string Mensagem, IEnumerable<ProdutoGetDto> Produtos) ObterProdutos()
        {
            var produtosGetDto = produtos.Select(p => new ProdutoGetDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                QtdEstoque = p.QtdEstoque
            });

            return (true, "Produtos obtidos com sucesso.", produtosGetDto);
        }

    }
}
