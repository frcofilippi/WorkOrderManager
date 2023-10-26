
namespace WorkOrderManager.Infrastructure.Authentication;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WorkOrderManager.Application.Services.JwtTokenGenerator;
using WorkOrderManager.Application.Services.TimeProvider;

public class JwtTokenGenerator : IJwtTokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeService _dateTimeService;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeService dateTimeService)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeService = dateTimeService;
    }

    public string CreateJwtToken(Guid userId, string firstName, string lastName)
    {
        var securityCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, _dateTimeService.DateTime.AddMinutes(_jwtSettings.LifeTimeInMinutes).ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims,
            expires: _dateTimeService.DateTime.AddMinutes(_jwtSettings.LifeTimeInMinutes),
            signingCredentials: securityCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public Task<AuthToken> GetCredentialsAsync(string user, string password)
    {
        throw new NotImplementedException();
    }
}