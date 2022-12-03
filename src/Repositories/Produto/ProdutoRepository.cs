using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models.DataService;
using E_Commerce_CasaDoCodigo.Repositories.Base;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_CasaDoCodigo.Repositories.Produto
{
    public class ProdutoRepository : BaseRepository<Models.Produto>,  IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        } 

        public IList<Models.Produto> GetProdutos()
        {
            return _DbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var item in livros)
            {
                if (!_DbSet.Where(x => x.Codigo == item.Codigo).Any())
                {
                    _DbSet.Add(new Models.Produto(item.Codigo, item.Nome, item.Preco));
                }
            }

            _applicationContext.SaveChanges();
        }
    }
}
