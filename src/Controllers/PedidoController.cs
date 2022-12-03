using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace E_Commerce_CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public IActionResult Carrossel(int pagina = 1)
        {
            var produtos = _produtoRepository.GetProdutos().ToPagedList(pagina, 24);

            return View(produtos);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            return View();
        }
    }
}

