using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Base;
using E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Commerce_CasaDoCodigo.Repositories.Pedido
{
    public class PedidoRepository : BaseRepository<Models.Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PedidoRepository(ApplicationContext applicationContext, IHttpContextAccessor httpContextAccessor) : base(applicationContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddItem(string codigo)
        {
            var produto = _applicationContext.Set<Models.Produto>().Where(x => x.Codigo == codigo).FirstOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();

            var itemPedido = _applicationContext.Set<Models.ItemPedido>().Where(x => x.Produto.Codigo == codigo && x.Pedido.Id == pedido.Id).SingleOrDefault();
            if (itemPedido == null)
            {
                itemPedido = new Models.ItemPedido(pedido, produto, 1, produto.Preco);
                _applicationContext.Set<Models.ItemPedido>().Add(itemPedido);

                _applicationContext.SaveChanges();
            }
        }

        public Models.Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = _DbSet.Include(y => y.Itens).ThenInclude(z => z.Produto).Where(x => x.Id == pedidoId).SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Models.Pedido();
                _DbSet.Add(pedido);

                _applicationContext.SaveChanges();

                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public int? GetPedidoId()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public void SetPedidoId(int pedidoId)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
