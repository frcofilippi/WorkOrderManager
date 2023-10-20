namespace WorkOrderManager.Presentation.Contracts.Clients;

public record ClientAddAddress(string Name,
    string Street,
    int StreetNumber,
    string City,
    bool isBilling,
    bool isShipping,
    string? Country = "AR");