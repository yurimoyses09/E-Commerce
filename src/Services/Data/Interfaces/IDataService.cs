using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Models.DataService;
using System.Collections.Generic;

namespace E_Commerce_CasaDoCodigo.Services.Interfaces
{
    public interface IDataService
    {
        void InicializaDb();
        void MontaDadosNaBase(ApplicationContext applicationContext);
        List<Livro> GetLivros();
    }
}
