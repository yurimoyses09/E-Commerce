using E_Commerce_CasaDoCodigo.Context;

namespace E_Commerce_CasaDoCodigo.Services.Interfaces
{
    public interface IDataService
    {
        void InicializaDb();

        void MontaDadosNaBase(ApplicationContext applicationContext);
    }
}
