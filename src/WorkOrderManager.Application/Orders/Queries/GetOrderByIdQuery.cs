
namespace WorkOrderManager.Application.Orders.Queries;

using ErrorOr;

using MediatR;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Domain.Common.Errors;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Domain.Orders.ValueObjects;
public class GetOrderByIdQuery : IRequest<ErrorOr<Order>>
{
    public string Id { get; set; }
}

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ErrorOr<Order>>
{
    private readonly IOrderRepository _repository;

    public GetOrderByIdQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetOrderById(OrderId.Create(new Guid(request.Id)));
        return order is not null ? order
                : Errors.Orders.OrderNotFound;
    }
}
