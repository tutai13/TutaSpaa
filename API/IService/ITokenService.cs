using API.DTOs.Auth;
using API.Models;
using Azure.Core;

namespace API.IService
{
    public interface ITokenService
    {
        public Task<TokenDTO> GenerateToken(User user , IList<string> Roles);
        public TokenDTO GenerateChangePasswordToken(User user );
        public Task<RefreshToken?> CheckFreshToken(string freshToken);


        public Task RevokeToken(string Token); 

    }
}
