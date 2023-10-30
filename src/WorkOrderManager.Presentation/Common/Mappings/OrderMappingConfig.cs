namespace WorkOrderManager.Presentation.Common.Mappings;

using Mapster;

using WorkOrderManager.Application.Orders.Commands;
using WorkOrderManager.Application.Orders.Queries;
using WorkOrderManager.Domain.Common;
using WorkOrderManager.Domain.Common.Entities;
using WorkOrderManager.Domain.Common.ValueObjects;
using WorkOrderManager.Presentation.Contracts.Orders.CreateOrder;
using WorkOrderManager.Presentation.Contracts.Orders.GetOrder;

public class OrderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateOrderRequest, CreateOrderCommand>()
        .Map(dest => dest.ClientName, src => $"{src.FirstName}, {src.LastName}")
        .Map(dest => dest, src => src);

        config.NewConfig<DeliveryAddressRequest, Address>()
        .MapWith(src => Address.CreateNew(src.Street, src.Number, src.City, src.Country));

        config.NewConfig<BillingAddressRequest, Address>()
        .MapWith(src => Address.CreateNew(src.Street, src.Number, src.City, src.Country));

        config.NewConfig<OrderLine, OrderLineResponse>()
        .Map(dst => dst.LineId, src => src.Id.Value)
        .Map(dst => dst.LineName, src => src.Name)
        .Map(dst => dst.LineDescription, src => src.Description);

        config.NewConfig<Order, CreateOrderResponse>()
        .Map(dest => dest.OrderId, src => src.Id.Value)
        .Map(dest => dest.OrderLines, src => src.OrderLines.ToList())
        .Map(dest => dest.ClienId, src => src.ClientId.Value.ToString())
        .Map(dest => dest.ClientName, src => src.ClientName)
        .Map(dst => dst.ShippingAddress, src => src.DeliveryAddress.FullAddress)
        .Map(dst => dst.BillingAddress, src => src.BillingAddress.FullAddress)
        .Map(dest => dest, src => src);

        config.NewConfig<GetOrderByIdRequest, GetOrderByIdQuery>()
        .Map(dest => dest.Id, src => src.Id);

        config.NewConfig<Address, Address>()
        .MapWith(src => Address.ParseAddressFromFullString(src.FullAddress));

        config.NewConfig<Order, GetOrderByIdResponse>()
        .Map(dest => dest.ClientName, src => src.ClientName)
        .Map(dest => dest.OrderLines, src => src.OrderLines
                                                .Select(x => new
                                                {
                                                    lineInfo = $"{x.Name} - {x.Description}",
                                                })
                                                .ToArray())
        .Map(dst => dst.BillingAddress, src => src.BillingAddress)
        .Map(dst => dst.ShippingAddress, src => src.DeliveryAddress);


        // .Map(dst => dst.ShippingAddress, src => Address.ParseAddressFromFullString(src.DeliveryAddress.FullAddress))
        // .Map(dst => dst.BillingAddress, src => Address.ParseAddressFromFullString(src.BillingAddress.FullAddress));
    }
}
