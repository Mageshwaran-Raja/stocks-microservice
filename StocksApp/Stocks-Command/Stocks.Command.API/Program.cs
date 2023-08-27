using Confluent.Kafka;
using CQRS.Core.Domain;
using CQRS.Core.Events;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using CQRS.Core.Producers;
using MongoDB.Bson.Serialization;
using Stocks.Command.API.Commands;
using Stocks.Command.Domain.Aggregates;
using Stocks.Command.Infrastructure.Config;
using Stocks.Command.Infrastructure.Dispatchers;
using Stocks.Command.Infrastructure.Handlers;
using Stocks.Command.Infrastructure.Producers;
using Stocks.Command.Infrastructure.Repositories;
using Stocks.Command.Infrastructure.Stores;
using Stocks.Common.Events;


var builder = WebApplication.CreateBuilder(args);

BsonClassMap.RegisterClassMap<BaseEvent>();
BsonClassMap.RegisterClassMap<StockCreatedEvent>();
BsonClassMap.RegisterClassMap<StockUpdatedEvent>();
BsonClassMap.RegisterClassMap<StockViewerCountUpdatedEvent>();

// Add services to the container.

builder.Services.Configure<MongoDBConfig>(builder.Configuration.GetSection(nameof(MongoDBConfig)));
builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection(nameof(ProducerConfig)));
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();
builder.Services.AddScoped<IEventProducer, EventProducer>();
builder.Services.AddScoped<IEventStore, EventStore>();
builder.Services.AddScoped<IEventSourcingHandler<StocksAggregate>, EventSourcingHandler>();
builder.Services.AddScoped<ICommandHandler, CommandHandler>();

var commandHandler = builder.Services.BuildServiceProvider().GetRequiredService<ICommandHandler>();
var dispatcher = new CommandDispatcher();
dispatcher.RegisterHandler<AddStocksCommand>(commandHandler.HandleAsync);
dispatcher.RegisterHandler<UpdateStocksCommand>(commandHandler.HandleAsync);
dispatcher.RegisterHandler<UpdateStockViewerCountCommand>(commandHandler.HandleAsync);
builder.Services.AddSingleton<ICommandDispatcher>(_ => dispatcher);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
