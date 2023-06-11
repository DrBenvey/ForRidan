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

        // GET: /stock/Read
        public async Task<IEnumerable<Stock>> Read()
        {
            return await _stockService.Read();
        }

        // DELETE: /stock/Delete
        public async Task Delete(int key)
        {
            await _stockService.Delete(key);
        }

        // PUT: /stock/Update
        public async Task Update(Stock obj)
        {
            await _stockService.Update(obj);
        }

        // POST: /stock/Create
        public async Task<Stock> Create(Stock obj)
        {
            return await _stockService.Create(obj);
        }
    }
}
