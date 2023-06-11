using BusinessLogic.Repository.MovementRepository;
using DataAccess.Entities;

namespace BusinessLogic.Service.MovementService
{
    public class CMovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public CMovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task<Movement> Create(Movement obj)
        {
            long IsOkToCreate = await _movementRepository.TryToUpdateForInsert(obj);
            if (IsOkToCreate != -1)
            {
                obj.balance = IsOkToCreate;
                return await _movementRepository.Create(obj);
            }
            else
                throw new Exception();
        }

        public async Task<long> GetReport(Movement obj)
        {
            Movement? tmp = await _movementRepository.ReadFirstBeforDate(obj);
            return tmp == null ? 0 : tmp.balance;
        }

        public async Task<List<Movement>> Read()
        {
            return await _movementRepository.Read();
        }
    }
}
