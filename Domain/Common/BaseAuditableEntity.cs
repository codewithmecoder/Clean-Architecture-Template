namespace Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity, IHasDomainEvents
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    private readonly List<BaseDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}