using Mapster;

using Microsoft.Data.SqlClient;

using WorkOrderManager.Application.Clients.Commands;
using WorkOrderManager.Application.Services.Authentication;
using WorkOrderManager.Domain.Clients;
using WorkOrderManager.Domain.Clients.Entities;
using WorkOrderManager.Presentation.Contracts.Authentincation;
using WorkOrderManager.Presentation.Contracts.Clients;

public class ClientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateClientRequest, CreateClientCommand>()
        .Map(dst => dst, src => src);

        config.NewConfig<Address, AddressResponse>()
        .Map(dst => dst.Name, src => src.Name)
        .Map(dst => dst.fullAddress, src => $"{src.Street}, {src.StreetNumber}, {src.City}, {src.Country}")
        .Map(dst => dst.addressId, src => src.Id.Value.ToString());

        config.NewConfig<Client, CreateClientResponse>()
        .Map(dst => dst.clientId, src => src.ClientId.Value.ToString())
        .Map(dst => dst.BillingAddresses, src => src.Addresses.Where(x => x.IsBilling == true))
        .Map(dst => dst.ShippingAddresses, src => src.Addresses.Where(x => x.IsShipping == true))
        .Map(dst => dst, src => src);

        config.NewConfig<(ClientAddAddress, Guid), AddClientAddressCommand>()
        .Map(dst => dst.ClientId, (src) => src.Item2)
        .Map(dest => dest, src => src.Item1)
        .Map(dst => dst.isShipping, src => src.Item1.isShipping)
        .Map(dst => dst.isBilling, src => src.Item1.isBilling);

        config.NewConfig<LoginRequest,LoginClientCommand>()
        .Map(dst => dst, src => src);

        config.NewConfig<AuthenticationResult, LoginResponse>()
        .Map(dst => dst.Token, src => src.Token)
        .Map(dst => dst.RefreshToken, src => src.RefreshToken)
        .Map(dst => dst.ExpiresIn, src => src.ExpiresIn);
    }
}