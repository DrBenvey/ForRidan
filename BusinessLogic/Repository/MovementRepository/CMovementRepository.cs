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
        
        public async Task<Movement> Create(Movement obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<List<Movement>> Read()
        {
            return await _context.Movements
                .Include(b => b.product)
                .Include(b => b.stock).ToListAsync();
        }
    }
}
