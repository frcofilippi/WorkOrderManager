using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkOrderManager.Application.Clients.Commands;
using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Presentation.Contracts.Clients;

namespace WorkOrderManager.Presentation.Controllers;
public class ClientController : ApiController
{
    private readonly ISender _mediattr;
    private readonly IMapper _mapper;

    public ClientController(ISender mediattr, IMapper mapper)
    {
        _mediattr = mediattr;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> New(CreateClientRequest request)
    {
        var createClientCommand = _mapper.Map<CreateClientCommand>(request);
        ErrorOr<Client> result = await _mediattr.Send(createClientCommand);
        return result.Match(
            client => new OkObjectResult(_mapper.Map<CreateClientResponse>(client)),
            errors => Problem(errors));
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress(ClientAddAddress request)
    {
        
    }
}