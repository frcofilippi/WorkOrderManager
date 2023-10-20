
namespace WorkOrderManager.Presentation.Common.Mappings;

using Mapster;
using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Presentation.Contracts.Authentincation;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationReponse>()
        .Map(dst => dst.Username, src => src.Username)
        .Map(dst => dst.Token, src => src.Token);
    }
}