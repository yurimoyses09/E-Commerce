using E_Commerce_CasaDoCodigo.Repositories.Produto;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Xunit;

namespace E_Commerce_CasaDoCodigo.Tests
{
    [TestFixture]
    public class ProdutoTestes
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoTestes(IProdutoRepository produtoRepository)
        {
            var service = new ServiceCollection();
            service.AddTransient<IProdutoRepository, ProdutoRepository>();

            var provider = service.BuildServiceProvider();

            _produtoRepository = provider.GetService<IProdutoRepository>();
        }

        [Test]
        public void Obter_Produto()
        {
            var retorno = _produtoRepository.GetProdutos();

            Assert.Equals(retorno, retorno);
        }
    }
}