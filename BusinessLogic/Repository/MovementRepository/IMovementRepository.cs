using BusinessLogic.Repository.Base;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository.MovementRepository
{
    public interface IMovementRepository: ICRRepository<Movement>
    {
        Task<Int64> TryToUpdateForInsert(Movement obj);
        Task<Movement?> ReadFirstBeforDate(Movement obj);

    }
}
