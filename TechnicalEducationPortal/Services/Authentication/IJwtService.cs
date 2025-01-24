using System.Security.Claims;

namespace TechnicalEducationPortal.Services.Authentication
{
    public interface IJwtService
    {
        string GenerateToken(string userData);
        ClaimsPrincipal ValidateToken(string token);
    }
}
