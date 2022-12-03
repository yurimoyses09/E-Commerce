using E_Commerce_CasaDoCodigo.Models.DataService;
using System.Collections.Generic;

namespace E_Commerce_CasaDoCodigo.Repositories.Produto.Interface
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
    }
}
