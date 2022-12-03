namespace E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface
{
    public interface IPedidoRepository
    {
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        Models.Pedido GetPedido();
        void AddItem(string codigo);
    }
}
