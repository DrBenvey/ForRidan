using BusinessLogic.Repository.ProductRepository;
using BusinessLogic.Repository.StockRepository;
using BusinessLogic.Service.ProductService;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.StockService
{
    public class CStockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public CStockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<List<Stock>> Read()
        {
            return await _stockRepository.Read();
        }

        public async Task<Stock> Create(Stock obj)
        {
            return await _stockRepository.Create(obj);
        }

        public async Task Delete(int key)
        {
            await _stockRepository.Delete(key);
        }

        public async Task Update(Stock obj)
        {
            await _stockRepository.Update(obj);
        }

    }
}
