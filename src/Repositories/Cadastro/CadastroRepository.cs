using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Base;

namespace E_Commerce_CasaDoCodigo.Repositories.Cadastro
{
    public class CadastroRepository : BaseRepository<Models.Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
