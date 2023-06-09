using BusinessLogic.Repository.ProductRepository;
using DataAccess.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLogic.Repository.MovementRepository
{
    public class CMovementRepository : IMovementRepository
    {
        private readonly Context _context;
        public CMovementRepository(Context context)
        {
            _context = context;
        }
        
        public async Task Create(Movement obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Movement obj)
        {
            Movement? old_obj = await _context.Movements.Where(e => e.id == obj.id).FirstOrDefaultAsync();
            if (old_obj != null)
            {
                old_obj = obj;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int key)
        {
            Movement? obj = await _context.Movements.Where(e => e.id == key).FirstOrDefaultAsync();
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public Task Delete(List<Movement> keys)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movement>> Read()
        {
            //throw new NotImplementedException();
            return await _context.Movements
                .Include(b => b.product)
                .Include(b => b.stock).ToListAsync();
        }
    }
}
