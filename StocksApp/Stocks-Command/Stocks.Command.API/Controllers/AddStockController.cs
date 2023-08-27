using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Stocks.Command.API.Commands;
using Stocks.Command.API.DTOs;
using Stocks.Common.DTOs;

namespace Stocks.Command.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AddStockController : ControllerBase
    {
        private readonly ILogger<AddStockController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public AddStockController(ILogger<AddStockController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> NewPostAsync(AddStocksCommand command)
        {
            var id = Guid.NewGuid();
            try
            {
                command.Id = id;
                await _commandDispatcher.SendAsync(command);

                return StatusCode(StatusCodes.Status201Created, new NewStockResponse
                {
                    Id = id,
                    Message = "New post creation request completed successfully!"
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
                return BadRequest(new BaseResponse
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while process to create a new post";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new NewStockResponse
                {
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}
