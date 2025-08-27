using Gradiscent.Domain.Models;

namespace Gradiscent.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task RemoveExpiredTokensAsync();
        Task UpdateAsync(RefreshToken token);

        Task RomoveAsync(RefreshToken token);
    }
}
