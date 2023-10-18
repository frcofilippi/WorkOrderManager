
namespace WorkOrderManager.Presentation.Controllers;

using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using WorkOrderManager.Application.Common.Repositories;
using WorkOrderManager.Application.Orders.Commands;
using WorkOrderManager.Application.Orders.Queries;
using WorkOrderManager.Domain.Orders;
using WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;
using WorkOrderManager.Presentation.Contracts.Orders.GetOrder;

[Authorize]
public class OrderController : ApiController
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderRepository _orderRepository;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository, ISender sender, IMapper mapper)
    {
        _logger = logger;
        _orderRepository = orderRepository;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery]GetOrderByIdRequest request)
    {
        var command = _mapper.Map<GetOrderByIdQuery>(request);
        ErrorOr<Order> getOrderByIdResult = await _sender.Send(command);
        return getOrderByIdResult.Match(
            orderResult => new OkObjectResult(_mapper.Map<GetOrderByIdResponse>(getOrderByIdResult)),
            errors => Problem(errors));
    }

    [HttpPost]
    public async Task<IActionResult> New(CreateOrderRequest request)
    {
        var command = _mapper.Map<CreateOrderCommand>(request);
        var order = await _sender.Send(command);
        return new JsonResult(_mapper.Map<CreateOrderResponse>(order));
    }
}
