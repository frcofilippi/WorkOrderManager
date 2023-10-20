
namespace WorkOrderManager.Application.Services.Identity;

public interface IIdentityService
{
    Task<Guid?> GetUserId();
}