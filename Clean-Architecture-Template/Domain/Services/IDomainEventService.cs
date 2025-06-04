using Domain.Common;

namespace Domain.Services;

public interface IDomainEventService
{
    Task PublishAsync(BaseDomainEvent domainEvent, CancellationToken cancellationToken = default);
}