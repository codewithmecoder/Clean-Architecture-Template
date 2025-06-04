using Application.Common.DTOs;
using MediatR;

namespace Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery(Guid id) : IRequest<OrderDto?>
{
    public Guid Id => id;
}