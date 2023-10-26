using System.Net.Http.Json;

using WorkOrderManager.Application.Services.JwtTokenGenerator;

public class FirebaseJwtTokenGenerator : IJwtTokenGeneratorService
{
    private readonly HttpClient _httpClient;

    public FirebaseJwtTokenGenerator(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string CreateJwtToken(Guid userId, string firstName, string lastName)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthToken> GetCredentialsAsync(string user, string password)
    {
        var loginRequest = new
        {
            email = user,
            password,
            returnSecureToken = true,
        };

        var response = await _httpClient.PostAsJsonAsync("",loginRequest);
        var token = await response.Content.ReadFromJsonAsync<AuthToken>();
        return token;
    }

}