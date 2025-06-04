using Domain.Common;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Events;

public class OrderStatusChangedEvent(Order order, OrderStatus oldStatus, OrderStatus newStatus) : BaseDomainEvent
{
    public Order Order => order;
    public OrderStatus OldStatus => oldStatus;
    public OrderStatus NewStatus => newStatus;
}