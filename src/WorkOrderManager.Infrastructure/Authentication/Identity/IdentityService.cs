using Microsoft.AspNetCore.Http;


namespace WorkOrderManager.Infrastructure.Authentication.Identity;

using WorkOrderManager.Application.Services.Identity;
using WorkOrderManager.Domain.Orders.ValueObjects;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _httpContext;

    public IdentityService(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public async Task<Guid?> GetUserId()
    {
        var userId = _httpContext.HttpContext.User.Claims
                                            .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                                            .Value;
        return string.IsNullOrEmpty(userId) ? null : new Guid(userId);
    }
}
