using Application.Common.DTOs;
using MediatR;

namespace Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public string CustomerId { get; set; } = string.Empty;
    public AddressDto ShippingAddress { get; set; } = new();
    public List<CreateOrderItemDto> Items { get; set; } = [];
}

public class CreateOrderItemDto
{
    public string ProductId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public string Currency { get; set; } = "USD";
    public int Quantity { get; set; }
}