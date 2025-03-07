using System.Globalization;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class ProdutosService : IProdutoService
    {
        private readonly List<Produto> _produto = new List<Produto>();
        public (bool Sucesso, string Mensagem) AdicionarProduto(Produto produto)
        {
            try
            {
                if (_produto.Any(x => x.Nome == produto.Nome)) return (false, "Produto já cadastrado!");
                if (produto.Quantidade <= 0) return (false, "Quantidade inválida!");
                produto.Preco = double.Parse(produto.Preco.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                if (produto.Preco <= 0) return (false, "Preço inválido!");
                if (string.IsNullOrEmpty(produto.Nome)) return (false, "Nome inválido!");
               
                _produto.Add(produto); return (true, "Produto adicionado com sucesso!");
            }
            catch (Exception)
            {
                return (false, "Erro ao adicionar produto!");
            }
        }
        public (bool Sucesso, string Mensagem) AtualizarEstoque(List<Produto> produtos, string nomeProduto, int quantidadeAlteracao)
        {
            // verifica se existe
            var produto = produtos.FirstOrDefault(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));

            if (produto == null)
            {
                return (false, "Produto não encontrado.");
            }

            if (quantidadeAlteracao == 0)
            {
                return (false, "Não houve alterações.");
            }

            if (produto.Quantidade + quantidadeAlteracao < 0)
            {
                return (false, "Estoque insuficiente.");
            }

            produto.Quantidade += quantidadeAlteracao;
            return (true, "Estoque atualizado com sucesso.");
        }


        public List<Produto> ListarProdutos()
        {
            return _produto;
        }
    }
}
