namespace WorkOrderManager.Presentation.Contracts.Authentincation;

public record LoginRequest(string Username, string Password);

public record LoginResponse(string Token, string RefreshToken, long ExpiresIn);