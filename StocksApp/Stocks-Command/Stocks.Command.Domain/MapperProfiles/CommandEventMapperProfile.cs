using AutoMapper;
using Stocks.Common.DTOs;
using Stocks.Common.Events;

namespace Stocks.Command.Domain.MapperProfiles
{
    public class CommandEventMapperProfile : Profile
    {
        public CommandEventMapperProfile() 
        {
            CreateMap<CreateStockDTO, StockCreatedEvent>();
        }
    }
}
