using Gradiscent.Application.Common;
using Gradiscent.Application.Dtos;

namespace Gradiscent.Application.Interfaces
{
    public interface IExternalAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginWithGoogleAsync(string requestedRole);
    }
}
