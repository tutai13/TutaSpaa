
using API.DTOs.Response;
using API.DTOs.Auth;

namespace API.IService
{
    public interface IAuthService
    {
        public Task<AuthResponse> Login(LoginDTO request);

        //public Task<AuthResponse> Resgister(RegisterDTO request);

        public Task<AuthResponse> RefreshToken(string refreshToken);

        public Task add(); 

        public Task<bool> ChangePassword(ResetPassDTO resetPassDTO);
        public Task Logout(string refreshToken);
    }
}
