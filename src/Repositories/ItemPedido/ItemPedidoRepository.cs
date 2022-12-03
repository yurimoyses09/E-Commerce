using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Base;

namespace E_Commerce_CasaDoCodigo.Repositories.ItemPedido
{
    public class ItemPedidoRepository : BaseRepository<Models.ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
