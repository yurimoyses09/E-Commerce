using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models.DataService;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using E_Commerce_CasaDoCodigo.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace E_Commerce_CasaDoCodigo.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext applicationContext, IProdutoRepository produtoRepository)
        {
            _applicationContext = applicationContext;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDb()
        {
            _applicationContext.Database.EnsureCreated();

            MontaDadosNaBase(_applicationContext);
        }

        public void MontaDadosNaBase(ApplicationContext applicationContext)
        {
            List<Livro> livros = GetLivros();

            _produtoRepository.SaveProdutos(livros);
        }

        public List<Livro> GetLivros()
        {
            var json = File.ReadAllText("C:\\Users\\ADM\\Downloads\\ASPNETCore20-5fc8ba0d3a47d8344c2bac9a32edfbe177b35a9d\\ASPNETCore20-5fc8ba0d3a47d8344c2bac9a32edfbe177b35a9d\\_Recursos\\dados\\livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            return livros;
        }
    }
}
