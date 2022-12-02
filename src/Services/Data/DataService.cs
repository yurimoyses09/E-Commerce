using CasaDoCodigo.Models;
using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models.DataService;
using E_Commerce_CasaDoCodigo.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace E_Commerce_CasaDoCodigo.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _applicationContext;

        public DataService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void InicializaDb()
        {
            _applicationContext.Database.EnsureCreated();

            MontaDadosNaBase(_applicationContext);
        }

        public void MontaDadosNaBase(ApplicationContext applicationContext)
        {
            var json = File.ReadAllText("C:\\Users\\ADM\\Downloads\\ASPNETCore20-5fc8ba0d3a47d8344c2bac9a32edfbe177b35a9d\\ASPNETCore20-5fc8ba0d3a47d8344c2bac9a32edfbe177b35a9d\\_Recursos\\dados\\livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            foreach (var item in livros)
            {
                _applicationContext.Set<Produto>().Add(new Produto(item.Codigo, item.Nome, item.Preco));
            }

            _applicationContext.SaveChanges();
        }
    }
}
