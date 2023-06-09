using BusinessLogic.Service.MovementService;
using BusinessLogic.Service.ProductService;
using BusinessLogic.Service.StockService;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IStockService _stokcService;
        private readonly IMovementService _movementService;
        public HomeController(ILogger<HomeController> logger, 
            IProductService productService, IStockService stockService, 
            IMovementService movementService)
        {
            _logger = logger;
            _productService = productService;
            _stokcService = stockService;
            _movementService = movementService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.Read();
            var stokcs = await _stokcService.Read();
            var movements = await _movementService.Read();
            int b = 2;
            return View();
        }
    }
}