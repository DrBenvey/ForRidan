using BusinessLogic.Service.MovementService;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace UserInterface.Controllers
{
    public class MovementController : ApiControllerAttribute
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovementService _movementService;
        public MovementController(ILogger<HomeController> logger, IMovementService movementService)
        {
            _logger = logger;
            _movementService = movementService;
        }
        // GET: /movement/Read
        public async Task<IEnumerable<Movement>> Read()
        {
            return await _movementService.Read();
        }

        // POST /movement/GetReport
        public async Task<Int64> GetReport(Movement obj)
        {
            return await _movementService.GetReport(obj);
        }

        // POST /movement/Create
        public async Task<Movement> Create(Movement obj)
        {
            return await _movementService.Create(obj);
        }
    }
}
