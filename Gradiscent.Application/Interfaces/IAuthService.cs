using Gradiscent.Application.Common;
using Gradiscent.Application.Dtos;

namespace Gradiscent.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> RegisterAsync(RegisterDto dto);
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto);
        Task<ApiResponse<LoginResponseDto>> RefreshTokenAsync(string token, string ipAddress);
        Task<ApiResponse<string>> VerifyEmailAsync(string userId, string token);
        Task LogoutAsync(string refreshToken);
    }
}
