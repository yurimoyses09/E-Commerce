using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models.DataService;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_CasaDoCodigo.Repositories.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ProdutoRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IList<Models.Produto> GetProdutos()
        {
            return _applicationContext.Set<Models.Produto>().ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var item in livros)
            {
                _applicationContext.Set<Models.Produto>().Add(new Models.Produto(item.Codigo, item.Nome, item.Preco));
            }

            _applicationContext.SaveChanges();
        }
    }
}
