using Mapster;

using WorkOrderManager.Application.Clients.Commands;
using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Presentation.Contracts.Clients;

public class ClientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientRequest, CreateClientCommand>()
        .Map(dst => dst, src => src);
        config.NewConfig<Client, CreateClientResponse>()
        .Map(dst => dst.clientId, src => src.Id.Value.ToString())
        .Map(dst => dst, src => src);
    }
}