using BusinessLogic.Repository.MovementRepository;
using BusinessLogic.Repository.ProductRepository;
using BusinessLogic.Service.ProductService;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.MovementService
{
    public class CMovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public CMovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public Task<Movement> Create(Movement obj)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movement>> Read()
        {
            return await _movementRepository.Read();
        }
    }
}
