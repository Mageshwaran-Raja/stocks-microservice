namespace Stocks.Command.API.Commands
{
    public interface ICommandHandler
    {
        Task HandleAsync(AddStocksCommand command);
        Task HandleAsync(UpdateStocksCommand command);
        Task HandleAsync(UpdateStockViewerCountCommand command);
    }
}