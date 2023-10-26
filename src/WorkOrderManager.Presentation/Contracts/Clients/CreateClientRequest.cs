using WorkOrderManager.Domain.Clients.Entities;

namespace WorkOrderManager.Presentation.Contracts.Clients;

public record CreateClientRequest(string FirstName, string LastName, string Password, string Email);
public record CreateClientResponse(string clientId, string FirstName, string LastName, string Email, string IdentityId,
                                   List<AddressResponse>? ShippingAddresses, List<AddressResponse>? BillingAddresses);

public record AddressResponse(string addressId, string Name, string fullAddress);