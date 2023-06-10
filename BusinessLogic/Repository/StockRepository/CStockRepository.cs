using BusinessLogic.Repository.ProductRepository;
using DataAccess.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repository.StockRepository
{
    public class CStockRepository : IStockRepository
    {
        private readonly Context _context;
        public CStockRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Stock>> Read()
        {
            return await _context.Stocks.ToListAsync();
        }
        
        public async Task<Stock> Create(Stock obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        
        public async Task Delete(int key)
        {
            Stock? obj = await _context.Stocks.Where(e => e.id == key).FirstOrDefaultAsync();
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task Update(Stock obj)
        {
            Stock? old_obj = await _context.Stocks.Where(e => e.id == obj.id).FirstOrDefaultAsync();
            if (old_obj != null)
            {
                old_obj.name = obj.name;
                old_obj.address = obj.address;
                await _context.SaveChangesAsync();
            }
        }
    }
}
