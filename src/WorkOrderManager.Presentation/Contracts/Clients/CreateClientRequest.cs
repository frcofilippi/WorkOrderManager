namespace WorkOrderManager.Presentation.Contracts.Clients;

public record CreateClientRequest(string FirstName, string LastName, string Password, string Email);
public record CreateClientResponse(string clientId, string FirstName, string LastName, string Email);
