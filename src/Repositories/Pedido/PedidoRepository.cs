using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Base;
using E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_CasaDoCodigo.Repositories.Pedido
{
    public class PedidoRepository : BaseRepository<Models.Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PedidoRepository(ApplicationContext applicationContext, IHttpContextAccessor httpContextAccessor) : base(applicationContext)
        {
            _httpContextAccessor = httpContextAccessor;
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
