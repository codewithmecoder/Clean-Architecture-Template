using Domain.Common;
using Domain.Enums;
using Domain.Events;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Order : BaseAuditableEntity
{
    public string OrderNumber { get; private set; }
    public string CustomerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public Money TotalAmount { get; private set; }
    public Address ShippingAddress { get; private set; }
    public DateTime OrderDate { get; private set; }

    private readonly List<OrderItem> _items = [];
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // For EF Core

    public Order(string customerId, Address shippingAddress)
    {
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
        ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
        OrderNumber = GenerateOrderNumber();
        Status = OrderStatus.Pending;
        OrderDate = DateTime.UtcNow;
        TotalAmount = Money.Zero("USD");

        AddDomainEvent(new OrderCreatedEvent(this));
    }

    public void AddItem(string productId, string productName, Money unitPrice, int quantity)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Cannot add items to a non-pending order");

        var item = new OrderItem(productId, productName, unitPrice, quantity);
        _items.Add(item);

        RecalculateTotal();
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        if (Status == newStatus) return;

        var oldStatus = Status;
        Status = newStatus;

        AddDomainEvent(new OrderStatusChangedEvent(this, oldStatus, newStatus));
    }

    private void RecalculateTotal()
    {
        var total = _items.Aggregate(Money.Zero("USD"), (acc, item) => acc.Add(item.TotalPrice));
        TotalAmount = total;
    }

    private static string GenerateOrderNumber()
    {
        return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..8].ToUpper()}";
    }
}