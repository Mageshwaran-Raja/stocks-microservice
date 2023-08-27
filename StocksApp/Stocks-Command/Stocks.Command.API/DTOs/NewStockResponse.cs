using Stocks.Common.DTOs;

namespace Stocks.Command.API.DTOs
{
    public class NewStockResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}
