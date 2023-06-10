using BusinessLogic.Service.StockService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class StockController : ApiControllerAttribute
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStockService _stockService;

        public StockController(ILogger<HomeController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }

        // GET: /product/Read
        public async Task<IEnumerable<Stock>> Read()
        {
            return await _stockService.Read();
        }

        // DELETE: /product/Delete
        public async Task Delete(int key)
        {
            await _stockService.Delete(key);
        }

        // PUT: /product/Update
        public async Task Update(Stock obj)
        {
            await _stockService.Update(obj);
        }

        // POST: /product/Create
        public async Task<Stock> Create(Stock obj)
        {
            return await _stockService.Create(obj);
        }
    }
}
