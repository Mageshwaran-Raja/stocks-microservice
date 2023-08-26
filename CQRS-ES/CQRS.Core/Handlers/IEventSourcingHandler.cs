namespace CQRS.Core.Handlers
{
    public interface IEventSourcingHandler<T>
    {
        Task<T> GetByIdAsync(Guid aggregateId);
    }
}
