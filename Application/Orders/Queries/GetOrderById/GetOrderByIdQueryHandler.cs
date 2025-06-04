using Application.Common.DTOs;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

        return order == null ? null : mapper.Map<OrderDto>(order);
    }
}