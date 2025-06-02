using API.Models;

namespace API.IRepository
{
    public interface ITokenRepository
    {
        public Task<RefreshToken> GetRefreshTokenByHash(string hashedToken);
        public Task<RefreshToken> GetFreshTokenByUserId(string UserID);
        Task CreateAsync(RefreshToken refreshToken);
        Task UpdateAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);
    }
}
