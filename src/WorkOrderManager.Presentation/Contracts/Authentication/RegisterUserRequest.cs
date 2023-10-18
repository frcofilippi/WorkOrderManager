namespace WorkOrderManager.Presentation.Contracts.Authentincation;

public record RegisterUserRequest(string FirstName, string LastName, string Username, string Password);
