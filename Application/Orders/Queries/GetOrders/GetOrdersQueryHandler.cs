using Application.Common.DTOs;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = string.IsNullOrEmpty(request.CustomerId)
            ? await orderRepository.GetAllAsync(cancellationToken)
            : await orderRepository.GetByCustomerIdAsync(request.CustomerId, cancellationToken);

        return mapper.Map<IEnumerable<OrderDto>>(orders);
    }
}