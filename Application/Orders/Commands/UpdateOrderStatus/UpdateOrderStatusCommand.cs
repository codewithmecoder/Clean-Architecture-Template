using Domain.Enums;
using MediatR;

namespace Application.Orders.Commands.UpdateOrderStatus;

public class UpdateOrderStatusCommand : IRequest
{
    public Guid OrderId { get; set; }
    public OrderStatus Status { get; set; }
}