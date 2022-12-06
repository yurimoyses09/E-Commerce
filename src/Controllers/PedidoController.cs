using E_Commerce_CasaDoCodigo.Models;
using E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Commerce_CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Carrossel()
        {
            try
            {
                var produtos = _produtoRepository.GetProdutos();

                return View(produtos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Cadastro()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IActionResult Carrinho(string codigo)
        {
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                {
                    _pedidoRepository.AddItem(codigo);
                }

                Pedido pedido = _pedidoRepository.GetPedido();

                return View(pedido.Itens);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IActionResult Resumo()
        {
            try
            {
                var pedido = _pedidoRepository.GetPedido();

                return View(pedido);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public void UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            throw new NotImplementedException();
        }
    }
}

