using Application.Common.DTOs;
using MediatR;

namespace Application.Orders.Queries.GetOrders;

public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
    public string? CustomerId { get; set; }
}