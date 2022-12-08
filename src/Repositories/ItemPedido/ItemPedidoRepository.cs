using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Base;
using System.Linq;

namespace E_Commerce_CasaDoCodigo.Repositories.ItemPedido
{
    public class ItemPedidoRepository : BaseRepository<Models.ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public void UpdatePedido(Models.ItemPedido itemPedido)
        {
            var itemPedidoDB = _DbSet.Where(x => x.Id == itemPedido.Id).SingleOrDefault();

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                _applicationContext.SaveChanges();
            }
        }
    }
}
