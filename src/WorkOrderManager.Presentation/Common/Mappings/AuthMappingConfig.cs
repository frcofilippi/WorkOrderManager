using Mapster;

using WorkOrderManager.Application.Services;
using WorkOrderManager.Presentation.Contracts.Authentincation;

namespace WorkOrderManager.Presentation.Common.Mappings;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationReponse>()
        .Map(dst => dst.Username, src => src.Username)
        .Map(dst => dst.Token, src => src.Token);
    }
}