using Microsoft.AspNetCore.Http;

namespace WorkOrderManager.Infrastructure.Authentication.Identity;

using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Domain.Common.ValueObjects;

using WorkUserManager.Application.Common.Repositories;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IClientRepository _clientRepository;

    public IdentityService(IHttpContextAccessor httpContext, IClientRepository clientRepository)
    {
        _httpContext = httpContext;
        _clientRepository = clientRepository;
    }

    public async Task<Guid?> GetUserId()
    {
        var userId = _httpContext.HttpContext.User.Claims
                                            .FirstOrDefault(c => c.Type == "user_id")
                                            .Value;
        var clientId = await _clientRepository.GetClientIdFromIdentityId(userId);
        return clientId is null ? null : clientId.Value;
    }
}
