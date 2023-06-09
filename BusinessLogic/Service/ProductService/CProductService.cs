using BusinessLogic.Repository.ProductRepository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLogic.Service.ProductService
{
    public class CProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public CProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Read()
        {
            return await _productRepository.Read();
        }

        public async Task Create(Product obj)
        {
            await _productRepository.Read();
        }

        public async Task Delete(int key)
        {
            await _productRepository.Delete(key);
        }

        public async Task Update(Product obj)
        {
            await _productRepository.Update(obj);
        }
    }
}
