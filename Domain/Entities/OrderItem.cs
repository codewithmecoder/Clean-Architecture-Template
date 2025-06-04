using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public string? ProductId { get; private set; }
    public string? ProductName { get; private set; }
    public Money UnitPrice { get; } = Money.Zero("USD");
    public int Quantity { get; }
    public Money TotalPrice => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

    // ReSharper disable once UnusedMember.Local
    private OrderItem() { } // For EF Core

    public OrderItem(string productId, string productName, Money unitPrice, int quantity)
    {
        ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

        Quantity = quantity;
    }
}