using ErrorOr;

using MediatR;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Domain.Common;
using WorkOrderManager.Domain.Common.Entities;
using WorkOrderManager.Domain.Common.Errors;
using WorkOrderManager.Domain.Common.ValueObjects;

namespace WorkOrderManager.Application.Orders.Commands;

public class CreateOrderCommandHanlder : IRequestHandler<CreateOrderCommand, ErrorOr<Order>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IIdentityService _identityService;


    public CreateOrderCommandHanlder(IOrderRepository orderRepository, IIdentityService identityService)
    {
        _orderRepository = orderRepository;
        _identityService = identityService;
    }

    public async Task<ErrorOr<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Guid? clientId = await _identityService.GetUserId();

        if (clientId is null)
        {
            return Errors.Authentication.CouldNotParseUserFromRequest;
        }

        var order = Order.CreateOrder(ClientId.Create((Guid)clientId), request.ClientName,
            Address.ParseAddressFromFullString(request.DeliveryAddress.FullAddress),
            Address.ParseAddressFromFullString(request.BillingAddress.FullAddress));

        foreach (var line in request.Lines)
        {
            order.AddLine(OrderLine.CreateItem(line.Name, line.Description));
        }

        var result = await _orderRepository.AddOrder(order);
        return result;
    }
}
