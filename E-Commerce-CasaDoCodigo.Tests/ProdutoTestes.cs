using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using NUnit.Framework;
using Xunit;

namespace E_Commerce_CasaDoCodigo.Tests
{
    public class ProdutoTestes
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoTestes(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [Fact]
        public void Obter_Produto()
        {
            var retorno = _produtoRepository.GetProdutos();

            Assert.Equals(retorno, retorno);
        }
    }
}