using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.IService;
using API.DTOs.Response;
using API.DTOs.Auth;
using API.Models;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;
        //private readonly IValidator<RegisterDTO> _validator; 


        public AuthService(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, ILogger<AuthService> logger) //IValidator<RegisterDTO> v )
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
            // _validator = v; 
        }

        public async Task<bool> ChangePassword(ResetPassDTO resetPassDTO)
        {
            if (resetPassDTO.NewPassword != resetPassDTO.ConfirmPassword)
                throw new Exception("Mật khẩu xác nhận không khớp");

            var user = await _userManager.FindByIdAsync(resetPassDTO.UserID);
            CheckUserNull(user);

            var checkPasswordResult =  await _userManager.CheckPasswordAsync(user, resetPassDTO.OldPassword);
            if (!checkPasswordResult)
                throw new Exception("Mật khẩu cũ không chính xác");

            var changePassResult = await _userManager.ChangePasswordAsync(user, resetPassDTO.OldPassword, resetPassDTO.NewPassword);
            if (!changePassResult.Succeeded)
            {
                _logger.LogWarning($"Đổi mật khẩu thất bại userId {user.Id} : " + string.Join(" | ", changePassResult.Errors.Select(e => e.Description)));
                throw new Exception("Đổi mật khẩu thất bại , vui lòng thử lại sau");
            }


            if (user.FisrtLogin)
            {
                user.FisrtLogin = false;
                await _userManager.UpdateAsync(user);
            }

            return true ; 

        }


        private void CheckUserNull(User user)
        {
            if (user == null)
                throw new Exception("User không tồn tại"); 
        }

        public async Task<AuthResponse> Login(LoginDTO request)
        {
            try
            {
                _logger.LogInformation("Login attempt for username: {UserName}", request.Email);

                var user = await _userManager.FindByEmailAsync(request.Email);
                CheckUserNull(user); 

                var loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!loginResult.Succeeded)
                {
                    _logger.LogWarning($"Đăng nhập thất bại Id tài khoản : {user.Id}");
                    return Failure("Sai mật khẩu");
                }


                //Nếu đăng nhập lần đầu , trả về token để đổi pass
                if (user.FisrtLogin)
                {
                    var changePassToken = _tokenService.GenerateChangePasswordToken(user);
                    return new AuthResponse
                    {
                        IsSuccess = true,
                        FirstLogin = user.FisrtLogin,
                        Message = "Đăng nhập lần đầu, vui lòng đổi mật khẩu để tiếp tục",
                        Token = changePassToken

                    };
                }

                _logger.LogInformation($"Login successfully user :  {user.Id}");
                var token = await _tokenService.GenerateToken(user, await _userManager.GetRolesAsync(user));
                return Success("Đăng nhập thành công", token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Đã xảy ra lỗi khi đăng nhập tài khoản :  {UserName}", request.Email + ex.InnerException?.Message  );
                return Failure("Xảy ra lỗi :" + ex.Message);
            }
        }


        private AuthResponse Success(string Message, TokenDTO token)
        {
            return new AuthResponse
            {
                IsSuccess = true,
                Token = token,
                Message = Message

            };
        }

        private AuthResponse Failure(string Message)
        {
            return new AuthResponse
            {
                IsSuccess = false,
                Token = null,
                Message = Message

            };
        }


        public async Task Logout(string refreshToken)
        {
            await _tokenService.RevokeToken(refreshToken);

            await _signInManager.SignOutAsync();
        }

        public async Task<AuthResponse> RefreshToken(string refreshToken)
        {
            try
            {
                var token = await _tokenService.CheckFreshToken(refreshToken);
                // Kiểm tra refresh token từ cơ sở dữ liệu hoặc bộ nhớ
                if (token is null)
                {
                    return Failure("Refresh token không hợp lệ hoặc đã hết hạn");
                }

                // Tìm người dùng theo UserID
                var user = await _userManager.FindByIdAsync(token.UserId);
                CheckUserNull(user); 

                // Tạo lại access token và refresh token mới
                var newToken = await _tokenService.GenerateToken(user, await GetRoles(user));


                return Success("Đăng nhập thành công", newToken);
            }
            catch (Exception ex)
            {
                return Failure("Xảy ra lỗi :" + ex.Message);
            }
        }

        private async Task<IList<string>> GetRoles(User user) => await _userManager.GetRolesAsync(user);

        public async Task add()
        {
            var user = new User()
            {
                Email = "duonng1203@gmail.com",
                UserName = "duongu7"
            };

            await _userManager.CreateAsync(user, "Gggggg@124"); 

            
        }

        //public async Task<ServiceResponse<TokenDTO>> Resgister(RegisterDTO request)
        //{
        //    var valid = await _validator.ValidateAsync(request);
        //    if (!valid.IsValid)
        //        return ServiceResponse<TokenDTO>.Failure(string.Join(", ", valid.Errors));


        //    var userExists = await _userManager.FindByNameAsync(request.Username);
        //    if (userExists != null)
        //        return ServiceResponse<TokenDTO>.Failure("Tên tài khoản đã tồn tại");


        //    var newUser = new User
        //    {
        //        UserName = string.Empty,
        //        DisplayName = request.DisplayName,
        //        Email = request.Email
        //    };



        //    var result = await _userManager.CreateAsync(newUser, request.Password).ConfigureAwaitFalse();

        //    if (!result.Succeeded)
        //    {
        //        return ServiceResponse<TokenDTO>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }

        //    await _userManager.AddToRoleAsync(newUser, "User").ConfigureAwaitFalse();
        //    _logger.LogInformation($"Đăng kí thành công {newUser.Id}");

        //    return ServiceResponse<TokenDTO>.Success(null, "Đăng kí thành công"); 
        //}
    }
}
