using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Stocks.Command.API.Commands;
using Stocks.Common.DTOs;

namespace Stocks.Command.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UpdateStockViewerCountController : ControllerBase
    {
        private readonly ILogger<UpdateStockViewerCountController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public UpdateStockViewerCountController(ILogger<UpdateStockViewerCountController> logger,
            ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> LikePostAsync(Guid id)
        {
            try
            {
                await _commandDispatcher.SendAsync(new UpdateStockViewerCountCommand { Id = id });

                return Ok(new BaseResponse
                {
                    Message = "Update Stock Viewer Count Request Completed Successfully!"
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
            catch (AggregateNotFoundException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Cannot retrieve the aggregate! Client Send a wrong Id");
                return BadRequest(new BaseResponse
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}
