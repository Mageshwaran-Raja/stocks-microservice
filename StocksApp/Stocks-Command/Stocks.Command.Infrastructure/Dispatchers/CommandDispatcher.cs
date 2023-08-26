﻿using CQRS.Core.Commands;
using CQRS.Core.Infrastructure;

namespace Stocks.Command.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Dictionary<Type, Func<BaseCommand, Task>> _handlers = new();
        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if (_handlers.ContainsKey(typeof(T))) 
            {
                throw new IndexOutOfRangeException("You cannot register the handler twice!.");
            }

            _handlers.Add(typeof(T), x => handler((T)x)); // casting BaseCommand T to Concrete command eg: AddStocksCommand
        }

        public async Task SendAsync(BaseCommand command)
        {
            if (_handlers.TryGetValue(command.GetType(), out Func<BaseCommand, Task> handler))
            {
                await handler(command);
            }
            else
            {
                throw new ArgumentNullException(nameof(handler), "No command handler was registered.");
            }
        }
    }
}
