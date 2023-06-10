using BusinessLogic.Service.ProductService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class ProductController :ApiControllerAttribute
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: /product/Read
        public async Task<IEnumerable<Product>> Read()
        {
            return await _productService.Read();
        }

        // DELETE: /product/Delete
        public async Task Delete(int key)
        {
            await _productService.Delete(key);
        }

        // PUT: /product/Update
        public async Task Update(string obj)
        {
            Product product=new Product(obj);
            await _productService.Update(product);
        }

        // POST: /product/Create
        public async Task<Product> Create(string obj)
        {
            Product product = new Product(obj);
            return await _productService.Create(product);
        }
    }
}
