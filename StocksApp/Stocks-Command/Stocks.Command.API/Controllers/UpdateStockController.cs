using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Stocks.Command.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UpdateStockController : ControllerBase
    {
        private readonly ILogger<UpdateStockController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public UpdateStockController(ILogger<UpdateStockController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }
    }
}
