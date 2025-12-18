using Gradiscent.Domain.Entities;

namespace Gradiscent.Application.Authentication.Common
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(JwtUserInfo user);
        RefreshToken GenerateRefreshToken(string userID);
    }
}
