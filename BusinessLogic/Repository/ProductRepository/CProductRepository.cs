using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repository.ProductRepository
{
    public class CProductRepository :IProductRepository
    {
        private readonly Context _context;
        public CProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Product>> Read()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task Create(Product obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int key)
        {
            Product? obj =await _context.Products.Where(e => e.id == key).FirstOrDefaultAsync();
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task Update(Product obj)
        {
            Product? old_obj = await _context.Products.Where(e => e.id == obj.id).FirstOrDefaultAsync();
            if (old_obj != null)
            {
                old_obj = obj;
                await _context.SaveChangesAsync();
            }
        }
    }
}
