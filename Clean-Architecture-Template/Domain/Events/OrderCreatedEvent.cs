using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class OrderCreatedEvent(Order order) : BaseDomainEvent
{
    public Order Order => order;
}