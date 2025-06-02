using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Security;
using API.Extensions;
using API.DTOs.Auth;
using API.IService;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }



        [HttpGet("Test/{message}")]
        [Authorize(AuthenticationSchemes = "Bearer" ) ]
        public IActionResult Test([FromRoute] string message)
        {
            return Ok(message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { Message = "Tên đăng nhập hoặc mật khẩu không được để trống." });
            }

            var result = await _authService.Login(request);
            if (!result.IsSuccess)
            {
                return BadRequest(new { result.Message });
            }

            if (!result.FirstLogin)
            {
                var refreshToken = result.Token.RefreshToken;
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/api/auth"
                };

                Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

            }

            return Ok(new { FisrtLogin = result.FirstLogin ,  AccessToken = result.Token.Accesstoken });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];
                if (string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogWarning("Refresh token không tồn tại trong request.");
                    return Unauthorized(new { Message = "Token không tồn tại." });
                }

                var result = await _authService.RefreshToken(refreshToken);
                if (!result.IsSuccess)
                {
                    return Unauthorized(new { result.Message });
                }

                Response.Cookies.Append("refreshToken", result.Token.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/api/auth"
                });

                return Ok(new { AccessToken = result.Token.Accesstoken });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi trong RefreshToken: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Đã xảy ra lỗi hệ thống." });
            }
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        //{
            
            
        //    if (request == null)
        //    {
        //        return BadRequest(new { message = "Dữ liệu không hợp lệ" });
        //    }

        //    var result = await _authService.Resgister(request);

        //    if (!result.IsSuccess)
        //    {
        //        return BadRequest(new { message = result.Message });
        //    }

        //    return Ok(new { message = result.Message });
        //}


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var refreshToken = Request.Cookies["refreshtoken"];
                if (string.IsNullOrEmpty(refreshToken))
                {
                    return BadRequest(new { Message = "Yêu câu không hợp lệ" });
                }

                await _authService.Logout(refreshToken);
                Response.Cookies.Delete("refreshtoken");

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = "Lỗi khi thực hiện yêu cầu: " + ex.Message });
            }
            
        }


        [HttpPost("reset-password")]
        [Authorize(AuthenticationSchemes ="Bearer" , Policy = "ChangePasswordOnly")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassDTO request)
        {
            try
            {
                request.UserID = User.GetUserId(); 
                var changePassResult = await _authService.ChangePassword(request);

                if (changePassResult)
                    return Ok();

                return BadRequest(new { message = "Đổi mật khẩu thất bài ,  vui lòng thử lại sau" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }





    }
}