using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1 если сделать такой приход расход нельзя или
        /// ожидаемое количество на заданную дату</returns>
        public async Task<long> TryToUpdateForInsert(Movement obj)
        {
            Movement? before = await ReadFirstBeforDate(obj);
            long current;
            if (before != null)
                current = before.balance + obj.balance;
            else
                current = obj.balance;
            if (current < 0)
                return -1;
            List<Movement> after= await _context.Movements.
                Where(m => m.id_product == obj.id_product && m.id_stock == obj.id_stock &&
                m.сreated > obj.сreated).ToListAsync();
            foreach (var movement in after)
            {
                movement.balance = movement.balance + obj.balance;
                if (movement.balance < 0)
                    return -1;
            }
            _context.SaveChanges();
            return current;
        }

        public async Task<List<Movement>> Read()
        {
            return await _context.Movements
                .Include(b => b.product)
                .Include(b => b.stock).ToListAsync();
        }

        public async Task<Movement?> ReadFirstBeforDate(Movement obj)
        {
            return await _context.Movements.
                Where(m => m.id_product == obj.id_product && m.id_stock == obj.id_stock &&
                m.сreated <= obj.сreated).OrderBy(m => m.сreated).LastOrDefaultAsync();
        }
    }
}
