using E_Commerce_CasaDoCodigo.Models;
using E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Commerce_CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Carrossel()
        {
            var produtos = _produtoRepository.GetProdutos();

            return View(produtos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo);
            }

            Models.Pedido pedido = _pedidoRepository.GetPedido();

            return View(pedido.Itens);
        }

        public IActionResult Resumo()
        {
            var pedido = _pedidoRepository.GetPedido();

            return View(pedido);
        }

        [HttpPost]
        public void UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            
        }
    }
}

